
namespace Domain.Abstractions;

public abstract class AggregateRoot<TEntityId>
    where TEntityId : IEntityId<TEntityId>
{
    public List<Event> Changes { get; set; } = [];
    public TEntityId? Id { get; set; }

    public AggregateRoot(TEntityId entityId)
    {
        Id = entityId;
    }

    public void MarkChangesAsCommitted()
    {
        Changes.Clear();
    }
}