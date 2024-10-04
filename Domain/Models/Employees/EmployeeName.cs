namespace Domain.Entities.Employees;

public struct EmployeeName : IEquatable<EmployeeName>, IFormattable
{
    private string Value { get; }

    public EmployeeName(string value)
    {
        Value = value;
    }

    public bool Equals(EmployeeName other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        return obj is EmployeeName other && Equals(other);
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