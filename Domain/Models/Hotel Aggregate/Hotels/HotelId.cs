using System.Diagnostics.CodeAnalysis;
using Domain.Abstractions;

namespace Domain.Models.Hotel_Aggregate.Hotels;

public struct HotelId : IEntityId<HotelId>, IEntityIdStatic<HotelId>
{
    public Guid Value { get; }

    public HotelId(Guid value)
    {
        Value = value;
    }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        FormattableString formattable = $"{Value}";
        return formattable.ToString(formatProvider);
    }

    public bool Equals(HotelId other)
    {
        return Value.Equals(other.Value);
    }

    public override string ToString()
    {
        return $"{Value}";
    }

    public static HotelId Parse(string s, IFormatProvider? provider)
    {
        return new HotelId(Guid.Parse(s));
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out HotelId result)
    {
        var succes = Guid.TryParse(s, out var guid);
        result = new HotelId(guid);
        return succes;
    }

    public static HotelId Next()
    {
        return new HotelId(Guid.NewGuid());
    }

    public static HotelId Empty => new HotelId(Guid.Empty);
}