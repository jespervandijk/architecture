using System.Dynamic;
using Domain.Entities;
using Domain.Models.Bookings.Events;
using Domain.Models.Customers;
using Marten.Events.Aggregation;

namespace Domain.Models.Bookings;

public class Booking : SingleStreamProjection<Booking>
{
    private readonly BookingValidator _bookingValidator = new BookingValidator();
    
    private Booking(BookingId id, CustomerId customerId, RoomId roomId, DateOnly checkInDate, DateOnly checkOutDate,
        BookingStatus status)
    {
        Id = id;
        CustomerId = customerId;
        RoomId = roomId;
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
        Status = status;
    }

    public BookingId Id { get; set; }
    public CustomerId CustomerId { get; set; }
    public RoomId RoomId { get; set; }
    public DateOnly CheckInDate { get; set; }
    public DateOnly CheckOutDate { get; set; }
    public BookingStatus Status { get; set; }

    public static void MakeBooking(CustomerId customerId, RoomId roomId, DateOnly checkInDate, DateOnly checkOutDate, BookingStatus status)
    {
        
    }

    public void Apply(BookingMade bookingMade)
    {
    }
}