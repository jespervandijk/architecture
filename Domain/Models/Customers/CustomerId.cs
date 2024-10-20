using System.Diagnostics.CodeAnalysis;
using Domain.Abstractions;

namespace Domain.Models.Customers;

public struct CustomerId : IEntityId<CustomerId>, IEntityIdStatic<CustomerId>
{
    public CustomerId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static CustomerId Next()
    {
        return new CustomerId(Guid.NewGuid());
    }
    
    public static CustomerId Empty => new CustomerId(Guid.Empty);

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        FormattableString formattable = $"{Value}";
        return formattable.ToString(formatProvider);
    }

    public override string ToString()
    {
        return $"{Value}";
    }

    public bool Equals(CustomerId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is CustomerId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static CustomerId Parse(string s, IFormatProvider? provider)
    {
        return new CustomerId(Guid.Parse(s));
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out CustomerId result)
    {
        var succes = Guid.TryParse(s, out var guid);
        result = new CustomerId(guid);
        return succes;
    }
}