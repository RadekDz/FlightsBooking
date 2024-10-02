using FlightsBooking.Domain.Common.Models;

namespace FlightsBooking.Domain.Flights.ValueObjects
{
    public sealed class Route : ValueObject
    {
        private Route(Airport from, Airport to)
        {
            From = from;
            To = to;
        }

        public Airport From { get; }
        public Airport To { get; }

        public static Route Create(Airport from, Airport to)
        {
            ArgumentNullException.ThrowIfNull(from);
            ArgumentNullException.ThrowIfNull(to);

            return new (from, to);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return From;
            yield return To;
        }
    }
}
