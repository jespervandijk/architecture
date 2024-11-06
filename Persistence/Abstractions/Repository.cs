using Application.Abstractions.Repositories;
using Domain.Abstractions;
using Marten;
using Microsoft.Extensions.Configuration;

namespace Persistence.Abstractions;

public class Repository<TEntity, TEntityId> : IRepository<TEntity, TEntityId>
    where TEntity : AggregateRoot<TEntityId>
    where TEntityId : IEntityId<TEntityId>
{
    private readonly IDocumentStore _eventStore;
    public Repository(IDocumentStore eventStore)
    {
        _eventStore = eventStore;
    }

    public async Task StartStream(TEntity aggregate, int? expectedVersion)
    {
        await using var session = _eventStore.LightweightSession();
        session.Events.StartStream<TEntity>(aggregate.Id.Value, aggregate.Changes);
        await session.SaveChangesAsync();
    }
    
    public async Task Save(TEntity aggregate, int? expectedVersion)
    {
        await using var session = _eventStore.LightweightSession();
        session.Events.Append(aggregate.Id.Value, aggregate.Changes);
        await session.SaveChangesAsync();
    }

    public async Task<TEntity> GetById(Guid id)
    {
        var aggregate = await _eventStore.LightweightSession().Events.AggregateStreamAsync<TEntity>(id);
        if (aggregate is null) throw new ArgumentException("Aggregate not found");
        return aggregate;
    }
}