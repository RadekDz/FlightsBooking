using FlightsBooking.Domain.Flights;
using FlightsBooking.Domain.Purchases.Entities;
using FlightsBooking.Domain.Common.ValueObjects;
using FlightsBooking.Domain.Purchases.Enums;

namespace FlightsBooking.Domain.Purchases.Policies
{
    public interface IDiscountPolicy
    {
        DiscountType DiscountType { get; }
        bool IsApplicable(Flight flight, DateTime departureDate, Tenant tenant);
        Money ApplyDiscount(Money price);
    }
}
