using Application.Abstractions;
using Carter;
using Domain.Models.Bookings;
using Domain.Models.Customers;
using Domain.Models.Hotel_Aggregate.Rooms;
using Marten;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Application.Features.Bookings;


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
    private readonly IDocumentStore _documentStore;
    
    
    
    public Task<BookingId> Handle(MakeBooking request, CancellationToken cancellationToken)
    {
        // get object
        // call method on object
        // domain validation
        // save events
        throw new NotImplementedException();
    }
}