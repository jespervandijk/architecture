using System.Reflection;
using System.Text.Json.Serialization;
using Domain.Abstractions;
using Domain.Models.Customers;

namespace API.JsonConverters;

public static class AddJsonConverters
{
    public static void AddConverters(this IList<JsonConverter> jsonConverters)
    {
        var apiAssembly = Assembly.GetExecutingAssembly();

        jsonConverters.AddConvertersAssembly(apiAssembly);
        jsonConverters.AddEntityIdConverters();
    }

    /// <summary>
    /// Adds all the json converters from an assembly.
    /// </summary>
    private static void AddConvertersAssembly(this IList<JsonConverter> jsonConverters, Assembly assembly)
    {
        var convertersTypesInAssembly = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && !t.IsGenericType && t.IsSubclassOf(typeof(JsonConverter)))
            .ToList();

        foreach (var converterType in convertersTypesInAssembly)
        {
            var converter = (JsonConverter)Activator.CreateInstance(converterType)!;
            jsonConverters.Add(converter);
        }
    }

    /// <summary>
    /// Creates json converters for all strongly typed ids and adds them.
    /// </summary>
    private static void AddEntityIdConverters(this IList<JsonConverter> jsonConverters)
    {
        var domain = Assembly.GetAssembly(typeof(CustomerId))!;

        var entityIdTypes = domain.GetTypes()
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityId<>)))
            .ToList();

        var entityConverterTypes = entityIdTypes.Select(x => typeof(EntityIdJsonConverter<>).MakeGenericType(x));

        foreach (var converterType in entityConverterTypes)
        {
            var converter = (JsonConverter)Activator.CreateInstance(converterType)!;
            jsonConverters.Add(converter);
        }
    }
}