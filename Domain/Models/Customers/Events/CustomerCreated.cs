using Domain.Abstractions;
using Qowaiv;

namespace Domain.Models.Customers.Events;

public record CustomerCreated : Event
{
    public required CustomerId Id { get; init; }
    public required CustomerName Name { get; init; }
    public required EmailAddress EmailAddress { get; init; }
}