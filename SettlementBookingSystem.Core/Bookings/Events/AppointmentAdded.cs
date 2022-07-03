using SettlementBookingSystem.Core.Common;

namespace SettlementBookingSystem.Core.Bookings.Events
{
    public record AppointmentAdded(Appointment Appointment) : IDomainEvent { }
}
