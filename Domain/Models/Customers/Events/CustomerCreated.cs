using Domain.Abstractions;

namespace Domain.Models.Customers.Events;

public record CustomerCreated : Event
{
    public required CustomerId Id { get; init; }
    public required CustomerName Name { get; init; }
    public required CustomerEmailAddress EmailAddress { get; init; }
}