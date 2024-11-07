using API.JsonConverters;
using JsonOptionsHttp = Microsoft.AspNetCore.Http.Json.JsonOptions;

namespace API.Extensions;

public static class JsonOptionExtensions
{
    public static JsonOptionsHttp AddConverters(this JsonOptionsHttp options)
    {
        options.SerializerOptions.Converters.AddConverters();
        return options;
    }
}