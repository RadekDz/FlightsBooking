using FlightsBooking.Domain.Common.Models;
using FlightsBooking.Domain.Purchases.Enums;
using FlightsBooking.Domain.Purchases.ValueObjects;

namespace FlightsBooking.Domain.Purchases.Entities
{
    public sealed class Tenant : Entity<TenantId>
    {
        private Tenant(
            TenantId tenantId,
            DateOnly birthDate,
            TenantType tenantType
           ) : base(tenantId)
        {
            BirthDate = birthDate;
            TenantType = tenantType;
        }

        public DateOnly BirthDate { get; private set; }

        public TenantType TenantType { get; private set; }

        public static Tenant Create(
            TenantId tenantId,
            DateOnly birthDate,
            TenantType tenantType)
        {
            return new(tenantId, birthDate, tenantType);
        }
    }
}
