using API.Abstractions;
using Carter;
using Domain.Entities;
using Domain.Models.Bookings;
using Domain.Models.Customers;
using MediatR;

namespace API.Features.Bookings;


public sealed class Endpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("bookings", async (MakeBooking command, ISender sender) =>
        {
            var bookingId = await sender.Send(command);

            return Results.Ok(bookingId);
        });
    }
}

public record MakeBooking : ICommand<BookingId>
{
    public CustomerId CustomerId { get; init; }
    public RoomId RoomId { get; init; }
    public DateOnly CheckInDate { get; init; }
    public DateOnly CheckOutDate { get; init; }
    public BookingStatus Status { get; init; }
}

public class MakeBookingHandler : ICommandHandler<MakeBooking, BookingId>
{
    public Task<BookingId> Handle(MakeBooking request, CancellationToken cancellationToken)
    {
        // get object
        // call method on object
        // domain validation
        // save events
        throw new NotImplementedException();
    }
}