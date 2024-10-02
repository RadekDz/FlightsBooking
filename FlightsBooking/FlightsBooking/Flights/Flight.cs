using FlightsBooking.Domain.Common.Models;
using FlightsBooking.Domain.Flights.ValueObjects;

namespace FlightsBooking.Domain.Flights
{
    public sealed class Flight : AggregateRoot<FlightId>
    {
        private Flight(FlightId flightId,
            Route route,
            Schedule schedule,
            List<FlightPrice> prices) : base(flightId)
        {
            Route = route;
            Schedule = schedule;
            Prices = prices;
        }

        public Route Route { get; private set; }

        public Schedule Schedule { get; private set; }

        public List<FlightPrice> Prices { get; set; }


        public static Flight Create(
            FlightId flightId,
            Route route,
            Schedule schedule,
            List<FlightPrice> prices)
        {
            return new(flightId, route, schedule, prices);
        }

        internal FlightPrice? GetPrice(DateTime departureDateUtc) => Prices.FirstOrDefault(p => p.DepartureDateUTC == departureDateUtc);
    }
}
