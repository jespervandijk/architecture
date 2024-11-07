using Domain.Abstractions;
using Domain.Models.GeneralValueObjects;
using Marten.Schema;

namespace Domain.Models.Customers.Events;

public record CustomerCreated : Event
{
    public required Guid StreamId { get; init; }
    public required CustomerName Name { get; init; }
    public required EmailAddress EmailAddress { get; init; }
}