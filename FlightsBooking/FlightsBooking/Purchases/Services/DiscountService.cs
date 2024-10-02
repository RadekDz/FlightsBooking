using FlightsBooking.Domain.Flights;
using FlightsBooking.Domain.Purchases.Entities;
using FlightsBooking.Domain.Purchases.Enums;
using FlightsBooking.Domain.Common.ValueObjects;
using FlightsBooking.Domain.Purchases.Policies;

namespace FlightsBooking.Domain.Purchases.Services
{
    public class DiscountService
    {
        private readonly List<IDiscountPolicy> _discountPolicies;

        public DiscountService(IEnumerable<IDiscountPolicy> discountPolicies)
        {
            _discountPolicies = new List<IDiscountPolicy>(discountPolicies);
        }

        public (Money FinalPrice, List<DiscountType> AppliedDiscounts) ApplyDiscounts(Flight flight, DateTime departureDateUtc, Tenant tenant)
        {
            var price = flight.GetPrice(departureDateUtc)?.Price;
            if (price == null)
            {
                throw new ArgumentException("Price for departure date not defined", nameof(departureDateUtc));
            }
            var appliedDiscounts = new List<DiscountType>();

            foreach (var policy in _discountPolicies)
            {
                if (policy.IsApplicable(flight, departureDateUtc, tenant))
                {
                    var newPrice = policy.ApplyDiscount(price);
                    if (newPrice.Amount < price.Amount)
                    {
                        price = newPrice;
                        appliedDiscounts.Add(policy.DiscountType);
                    }
                }
            }


            return (price, appliedDiscounts);
        }
    }
}
