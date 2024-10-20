using Domain.Models.Customers;
using Domain.Models.Hotel_Aggregate.Rooms;

namespace Domain.Models.Bookings.Events;

public record BookingMade
{
    public required BookingId Id { get; init; }
    public required CustomerId CustomerId { get; init; }
    public required RoomId RoomId { get; init; }
    public required DateOnly CheckInDate { get; init; }
    public required DateOnly CheckOutDate { get; init; }
    public required BookingStatus Status { get; init; }
}