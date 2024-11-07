using System.Text.Json;
using System.Text.Json.Serialization;
using Domain.Models.Customers;

namespace API.JsonConverters;

public class CustomerNameJsonConverter : JsonConverter<CustomerName>
{
    public override CustomerName Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (value is null) throw new JsonException();
        return new CustomerName(value);
    }

    public override void Write(Utf8JsonWriter writer, CustomerName value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}