using System.Reflection;
using System.Text.Json.Serialization;
using Domain.Abstractions;
using Domain.Models.Customers;

namespace API.Configuration.JsonOptions;

public static class JsonOptionExtensions
{
    public static Microsoft.AspNetCore.Http.Json.JsonOptions AddConverters(this Microsoft.AspNetCore.Http.Json.JsonOptions jsonOptions)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var domain = Assembly.GetAssembly(typeof(CustomerId));
        
        var convertersTypesInAssembly = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && !t.IsGenericType && t.IsSubclassOf(typeof(JsonConverter)))
            .ToList();
        
        foreach (var converterType in convertersTypesInAssembly)
        {
            var converter = (JsonConverter)Activator.CreateInstance(converterType);
            jsonOptions.SerializerOptions.Converters.Add(converter);
        }
        
        var entityIdTypes = domain.GetTypes()
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityId<>)))
            .ToList();
        
        var entityConverterTypes = entityIdTypes.Select(x => typeof(EntityIdJsonConverter<>).MakeGenericType(x));
        
        foreach (var converterType in entityConverterTypes)
        {
            var converter = (JsonConverter)Activator.CreateInstance(converterType);
            jsonOptions.SerializerOptions.Converters.Add(converter);
        }
        
        return jsonOptions;
    }
}