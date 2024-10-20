using Qowaiv;

namespace Domain.Models.Customers.Events;

public record CustomerAdded
{
    public required CustomerId Id { get; init; }
    public required CustomerName Name { get; init; }
    public required EmailAddress EmailAddress { get; init; }
}