namespace Domain.Models.Customers;

public struct CustomerEmailAddress : IFormattable, IEquatable<CustomerEmailAddress>
{
    public string Value { get; }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        FormattableString formattable = $"{Value}";
        return formattable.ToString(formatProvider);
    }

    public override string ToString()
    {
        return $"{Value}";
    }

    public bool Equals(CustomerEmailAddress other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        return obj is CustomerEmailAddress other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}