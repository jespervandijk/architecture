using Application.Abstractions.Repositories;
using Domain.Abstractions;
using Marten;

namespace Infrastructure.Abstractions;

public class Repository<TEntity, TEntityId> : IRepository<TEntity, TEntityId>
    where TEntity : AggregateRoot<TEntityId>
    where TEntityId : IEntityId<TEntityId>
{
    private readonly IDocumentStore _eventStore;

    public Repository(IDocumentStore eventStore)
    {
        _eventStore = eventStore;
    }

    public void StartStream(TEntity aggregate, int? expectedVersion)
    {
        _eventStore.LightweightSession().Events.StartStream<TEntity>(aggregate.Id.Value, aggregate.Changes);
    }
    
    public void Save(TEntity aggregate, int? expectedVersion)
    {
        _eventStore.LightweightSession().Events.Append(aggregate.Id.Value, aggregate.Changes);
    }

    public async Task<TEntity> GetById(Guid id)
    {
        var aggregate = await _eventStore.LightweightSession().Events.AggregateStreamAsync<TEntity>(id);
        if (aggregate is null) throw new ArgumentException("Aggregate not found");
        return aggregate;
    }
}