
namespace Domain.Abstractions;

public interface IAggregateRoot<TEntityId>
    where TEntityId : IEntityId<TEntityId>
{
    public TEntityId Id { get; }
    public List<Event> Changes { get; set; }
}

public abstract class AggregateRoot<TEntityId>
    where TEntityId : IEntityId<TEntityId>
{
    public List<Event> Changes { get; set; } = [];

    public void MarkChangesAsCommitted()
    {
        Changes.Clear();
    }
}