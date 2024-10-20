using System.Diagnostics.CodeAnalysis;
using Domain.Abstractions;

namespace Domain.Models.Employees;

public struct EmployeeId : IEntityId<EmployeeId>, IEntityIdStatic<EmployeeId>
{
    public EmployeeId(Guid value)
    {
        Value = value;
    }
    
    public Guid Value { get; }

    public bool Equals(EmployeeId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is EmployeeId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static EmployeeId Next()
    {
        return new EmployeeId(Guid.NewGuid());
    }

    public static EmployeeId Empty { get; }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        FormattableString formattable = $"{Value}";
        return formattable.ToString(formatProvider);
    }

    public override string ToString()
    {
        return $"{Value}";
    }

    public static EmployeeId Parse(string s, IFormatProvider? provider)
    {
        return new EmployeeId(Guid.Parse(s));
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out EmployeeId result)
    {
        var succes = Guid.TryParse(s, out var guid);
        result = new EmployeeId(guid);
        return succes;
    }
}