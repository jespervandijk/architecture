using Domain.Models.Bookings.Events;
using Marten;

namespace API.Extensions;

public static class MartenDbOptionsExtensions
{
    public static StoreOptions AddEventTypes(this StoreOptions options)
    {
        options.Events.AddEventType<BookingMade>();
        
        return options;
    }
}