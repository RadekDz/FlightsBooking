using FlightsBooking.Domain.Flights;
using FlightsBooking.Domain.Purchases.Entities;
using FlightsBooking.Domain.Purchases.Enums;

namespace FlightsBooking.Domain.Purchases.Policies
{
    public class BirthdayDiscountPolicy : DiscountPolicy
    {
        public override DiscountType DiscountType => throw new NotImplementedException();

        public override bool IsApplicable(Flight flight, DateTime departureDate, Tenant tenant)
        {
            return departureDate.Month == tenant.BirthDate.Month &&
                   departureDate.Day == tenant.BirthDate.Day;
        }
    }
}
