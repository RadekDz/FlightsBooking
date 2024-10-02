using FlightsBooking.Domain.Common.Models;
using FlightsBooking.Domain.Common.ValueObjects;

namespace FlightsBooking.Domain.Flights.ValueObjects
{
    public sealed class FlightPrice : ValueObject
    {
        public FlightPrice(DateTime departureDateUTC, Money price) 
        {
            DepartureDateUTC = departureDateUTC;
            Price = price;
        }

        public DateTime DepartureDateUTC { get;}

        public Money Price { get;}

        public static FlightPrice Create(DateTime departureDateUTC, Money price)
        {
            ArgumentNullException.ThrowIfNull(price);

            return new (departureDateUTC, price);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DepartureDateUTC;
            yield return Price;
        }
    }
}
