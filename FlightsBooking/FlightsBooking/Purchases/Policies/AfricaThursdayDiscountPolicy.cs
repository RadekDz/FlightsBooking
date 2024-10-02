using FlightsBooking.Domain.Flights;
using FlightsBooking.Domain.Purchases.Entities;
using FlightsBooking.Domain.Purchases.Enums;
using FlightsBooking.Domain.Common.Enums;

namespace FlightsBooking.Domain.Purchases.Policies
{
    public class AfricaThursdayDiscountPolicy : DiscountPolicy
    {
        public override DiscountType DiscountType { get => DiscountType.AfricaThursdayDiscount; }
        public override bool IsApplicable(Flight flight, DateTime departureDate, Tenant tenant)
        {
            return flight.Route.To.Continent == Continent.Africa &&
                   departureDate.DayOfWeek == DayOfWeek.Thursday;
        }
    }
}
