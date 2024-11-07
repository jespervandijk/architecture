using System.Text.Json;
using System.Text.Json.Serialization;
using Domain.Models.GeneralValueObjects;

namespace API.JsonConverters;

public class CustomerEmailJsonConverter : JsonConverter<EmailAddress>
{
    public override EmailAddress Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (value is null) throw new JsonException();
        return new EmailAddress(value);
    }

    public override void Write(Utf8JsonWriter writer, EmailAddress value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}