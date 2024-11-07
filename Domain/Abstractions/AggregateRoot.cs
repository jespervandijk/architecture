
using System.Text.Json.Serialization;
using Marten.Schema;

namespace Domain.Abstractions;

public abstract class AggregateRoot
{
    [Identity]
    // Needs public set for Marten
    // Marten documents work better with a Guid as streamId instead of a strongly typed Id
    public Guid StreamId { get; set; }
    
    [JsonIgnore]
    public List<Event> Changes { get; protected set; } = [];

    // Empty Constructor for Marten
    protected AggregateRoot()
    {
    }
    public AggregateRoot(Guid? streamId)
    {
        StreamId = streamId ?? Guid.NewGuid();
    }

    public void MarkChangesAsCommitted()
    {
        Changes.Clear();
    }
}