namespace Domain.Models.Customers;

public struct CustomerName : IEquatable<CustomerName>, IFormattable
{
    private string Value { get; }

    public CustomerName(string value)
    {
        Value = value;
    }

    public bool Equals(CustomerName other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        return obj is CustomerName other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        FormattableString formattable = $"{Value}";
        return formattable.ToString(formatProvider);
    }

    public override string ToString()
    {
        return $"{Value}";
    }
}