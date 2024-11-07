using Domain.Abstractions;

namespace Application.Abstractions.Repositories;

public interface IRepository<TEntity> 
    where TEntity : AggregateRoot
{
    public Task StartStream(TEntity aggregate, int? expectedVersion);
    public Task Save(TEntity aggregate, int? expectedVersion);
    public Task<TEntity> GetById(Guid id);
}