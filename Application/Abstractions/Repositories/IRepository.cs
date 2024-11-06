using Domain.Abstractions;

namespace Application.Abstractions.Repositories;

public interface IRepository<TEntity, TEntityId> 
    where TEntity : AggregateRoot<TEntityId>
    where TEntityId : IEntityId<TEntityId>
{
    public Task StartStream(TEntity aggregate, int? expectedVersion);
    public Task Save(TEntity aggregate, int? expectedVersion);
    public Task<TEntity> GetById(Guid id);
}