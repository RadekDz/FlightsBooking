using FlightsBooking.Domain.Common.Models;
using System.Text.RegularExpressions;

namespace FlightsBooking.Domain.Flights.ValueObjects
{
    public sealed class FlightId : ValueObject
    {
        private FlightId(string value) => Value = value;

        public string Value { get; }

        public static FlightId Create(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(value));
            ValidateFlightIdFormat(value);

            return new(value);
        }

        private static void ValidateFlightIdFormat(string value)
        {
            string pattern = @"^[A-Za-z]{3}\d{5}[A-Za-z]{3}$";
            if (!Regex.IsMatch(value, pattern))
                throw new ArgumentException("Invalid FlightId format");
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
