namespace Domain.Models.Bookings;

public struct BookingId : IEquatable<BookingId>, IFormattable
{
    private Guid Value { get; }

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
}