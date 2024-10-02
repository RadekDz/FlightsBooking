using FlightsBooking.Domain.Flights;
using FlightsBooking.Domain.Purchases.Entities;
using FlightsBooking.Domain.Common.ValueObjects;
using FlightsBooking.Domain.Purchases.Enums;

namespace FlightsBooking.Domain.Purchases.Policies
{
    public abstract class DiscountPolicy : IDiscountPolicy
    {
        protected const decimal DiscountAmount = 5m;
        protected const decimal MinimalPrice = 20m;

        public abstract bool IsApplicable(Flight flight, DateTime departureDate, Tenant tenant);

        public abstract DiscountType DiscountType { get; }

        public virtual Money ApplyDiscount(Money price)
        {
            return Money.Create(Math.Max(price.Amount - DiscountAmount, MinimalPrice), price.Currency);
        }
    }
}
