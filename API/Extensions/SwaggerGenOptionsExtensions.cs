using System.Reflection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace API.Extensions;

public static class SwaggerGenOptionsExtensions
{
    private static SwaggerGenOptions UseOpenApiDataTypeAttributes(this SwaggerGenOptions options, Assembly assembly)
    {
        var types = assembly.GetTypes()
            .Where(t => t.GetCustomAttributes(typeof(OpenApiDataTypeAttribute)).Count() > 0)
            .ToList();

        foreach (var type in types)
        {
            var attribute = type.GetCustomAttribute<OpenApiDataTypeAttribute>();
            if (attribute is null) continue;
            
            options.MapType(type,() =>
                new OpenApiSchema
                {
                    Type = attribute.Type,
                    Example = OpenApiAnyFactory.CreateFromJson(attribute.Example.ToString()),
                    Format = attribute.Format,
                    Pattern = attribute.Pattern,
                    Nullable = attribute.Nullable,
                });
        }

        return options;
    }

    public static SwaggerGenOptions AddSwaggerGenOptions(this SwaggerGenOptions options)
    {
        options.SupportNonNullableReferenceTypes();
        options.UseOpenApiDataTypeAttributes(typeof(OpenApiDataTypeAttribute).Assembly);
        return options;
    }
}