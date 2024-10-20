namespace Domain.Abstractions;

public interface IEntity<TEntityId>
where TEntityId : struct, IEntityId<TEntityId>
{
    public TEntityId Id { get; }
}