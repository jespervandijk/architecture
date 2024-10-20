using System.Diagnostics.CodeAnalysis;
using Domain.Abstractions;

namespace Domain.Models.Hotel_Aggregate.Rooms;

public struct RoomId : IEntityId<RoomId>, IEntityIdStatic<RoomId>
{
    public Guid Value { get; }

    public RoomId(Guid value)
    {
        Value = value;
    }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        FormattableString formattable = $"{Value}";
        return formattable.ToString(formatProvider);
    }

    public bool Equals(RoomId other)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return $"{Value}";
    }

    public static RoomId Parse(string s, IFormatProvider? provider)
    {
        return new RoomId(Guid.Parse(s));
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out RoomId result)
    {
        var succes = Guid.TryParse(s, out var guid);
        result = new RoomId(guid);
        return succes;
    }

    public static RoomId Next()
    {
        return new RoomId(Guid.NewGuid());
    }

    public static RoomId Empty => new RoomId(Guid.Empty);
}