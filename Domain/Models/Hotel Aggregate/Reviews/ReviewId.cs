using System.Diagnostics.CodeAnalysis;
using Domain.Abstractions;

namespace Domain.Models.Hotel_Aggregate.Reviews;

public struct ReviewId : IEntityId<ReviewId>, IEntityIdStatic<ReviewId>
{
    public Guid Value { get; }

    public ReviewId(Guid value)
    {
        Value = value;
    }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        FormattableString formattable = $"{Value}";
        return formattable.ToString(formatProvider);
    }

    public bool Equals(ReviewId other)
    {
        return Value.Equals(other.Value);
    }

    public override string ToString()
    {
        return $"{Value}";
    }

    public static ReviewId Parse(string s, IFormatProvider? provider)
    {
        return new ReviewId(Guid.Parse(s));
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ReviewId result)
    {
        var succes = Guid.TryParse(s, out var guid);
        result = new ReviewId(guid);
        return succes;
    }

    public static ReviewId Next()
    {
        return new ReviewId(Guid.NewGuid());
    }

    public static ReviewId Empty => new ReviewId(Guid.Empty);
}