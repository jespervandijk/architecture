using System.Text.Json;
using System.Text.Json.Serialization;
using Domain.Abstractions;

namespace API.JsonConverters;

public class EntityIdJsonConverter<TEntityId> : JsonConverter<TEntityId>
    where TEntityId : struct, IEntityId<TEntityId>
{
    public override TEntityId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (value is null) throw new JsonException();
        return (TEntityId)Activator.CreateInstance(typeof(TEntityId), Guid.Parse(value))!;
    }

    public override void Write(Utf8JsonWriter writer, TEntityId value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}