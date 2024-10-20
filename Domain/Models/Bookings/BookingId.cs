using System.Diagnostics.CodeAnalysis;
using Domain.Abstractions;

namespace Domain.Models.Bookings;

public struct BookingId : IEntityId<BookingId>, IEntityIdStatic<BookingId>
{
    public Guid Value { get; }

    public BookingId(Guid value)
    {
        Value = value;
    }

    public static BookingId Next()
    {
        return new BookingId(Guid.NewGuid());
    }
    
    public static BookingId Empty => new BookingId(Guid.Empty);

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        FormattableString formattable = $"{Value}";
        return formattable.ToString(formatProvider);
    }

    public override string ToString()
    {
        return $"{Value}";
    }

    public bool Equals(BookingId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is BookingId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static BookingId Parse(string s, IFormatProvider? provider)
    {
        return new BookingId(Guid.Parse(s));
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out BookingId result)
    {
        var succes = Guid.TryParse(s, out var guid);
        result = new BookingId(guid);
        return succes;
    }
}