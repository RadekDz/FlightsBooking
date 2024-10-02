using FlightsBooking.Domain.Common.Models;

namespace FlightsBooking.Domain.Purchases.ValueObjects
{
    public sealed class TenantId : ValueObject
    {
        private TenantId(Guid value) => Value = value;

        public Guid Value { get; }

        public static TenantId Create(Guid value) => new(value);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
