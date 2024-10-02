using FlightsBooking.Domain.Common.Enums;
using FlightsBooking.Domain.Common.Models;

namespace FlightsBooking.Domain.Flights.ValueObjects
{
    public sealed class Airport: ValueObject
    {
        private Airport(string name, Continent continent)
        {
            Name = name;
            Continent = continent;
        }

        public string Name { get; }
        public Continent Continent { get;  }

        public static Airport Create(string name, Continent continent)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
            return new(name, continent);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Continent;
        }
    }
}
