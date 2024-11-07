using API.JsonConverters;
using Domain.Models.Bookings.Events;
using Domain.Models.Customers;
using Domain.Models.Customers.Events;
using Marten;
using Marten.Events.Projections;
using Persistence;
using Weasel.Core;

namespace API.Extensions;

public static class MartenDbOptionsExtensions
{
    public static StoreOptions AddEventTypes(this StoreOptions options)
    {
        options.Events.AddEventType<CustomerCreated>();
        
        options.Projections.Add<CustomerProjection>(ProjectionLifecycle.Inline);
        
        options.UseSystemTextJsonForSerialization(enumStorage: EnumStorage.AsString,
            configure: settings => settings.Converters.AddConverters());

        return options;
    }
}