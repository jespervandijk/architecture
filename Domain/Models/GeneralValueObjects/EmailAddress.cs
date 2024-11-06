using Domain.Attributes;

namespace Domain.Models.GeneralValueObjects;

[OpenApiDataType(description: "Email Address", example: "test@test", type: "string" )]
public struct EmailAddress : IFormattable, IEquatable<EmailAddress>
{
    public string Value { get; }

    public EmailAddress(string emailAddress)
    {
        Value = emailAddress;
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

    public bool Equals(EmailAddress other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        return obj is EmailAddress other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}