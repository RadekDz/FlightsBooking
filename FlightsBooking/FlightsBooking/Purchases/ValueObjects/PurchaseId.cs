using FlightsBooking.Domain.Common.Models;

namespace FlightsBooking.Domain.Purchases.ValueObjects
{
    public sealed class PurchaseId : ValueObject
    {
        private PurchaseId(Guid value) => Value = value;
 
        public Guid Value { get; }

        internal static PurchaseId Create(Guid value) => new (value);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
