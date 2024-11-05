namespace Domain.Abstractions;

public abstract record Event
{
    public int Version { get; set; }
}