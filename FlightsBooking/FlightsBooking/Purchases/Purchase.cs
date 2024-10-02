using FlightsBooking.Domain.Common.Models;
using FlightsBooking.Domain.Common.ValueObjects;
using FlightsBooking.Domain.Flights.ValueObjects;
using FlightsBooking.Domain.Purchases.Entities;
using FlightsBooking.Domain.Purchases.Enums;
using FlightsBooking.Domain.Purchases.ValueObjects;

namespace FlightsBooking.Domain.Purchases

{
    public sealed class Purchase : AggregateRoot<PurchaseId>
    {
        private Purchase(PurchaseId id, FlightId flightId, Tenant tenant, Money finalPrice, List<DiscountType> appliedDiscounts)
            : base(id)
        {
            FlightId = flightId;
            Tenant = tenant;
            FinalPrice = finalPrice;
            AppliedDiscounts = appliedDiscounts;
        }

        public FlightId FlightId { get; private set; }

        public Tenant Tenant { get; private set; }
        
        public Money FinalPrice { get; private set; }
        
        public List<DiscountType> AppliedDiscounts { get; private set; }

        public static Purchase Create(PurchaseId id, FlightId flightId, Tenant tenant, Money finalPrice, List<DiscountType> appliedDiscounts)
        {
            var discounts = tenant.TenantType == TenantType.TypeB ? new List<DiscountType>() : appliedDiscounts;

            return new Purchase(id, flightId, tenant, finalPrice, discounts);
        }
    }
}
