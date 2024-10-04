namespace Domain.Entities.Employees;

public struct EmployeeId : IEquatable<EmployeeId>
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
}