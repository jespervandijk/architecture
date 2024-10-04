using FluentValidation;

namespace Domain.Models.Bookings;

public class BookingValidator : AbstractValidator<Booking>
{
    public BookingValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty();
    }
}