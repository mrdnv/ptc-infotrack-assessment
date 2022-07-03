using SettlementBookingSystem.Core.Common;
using static SettlementBookingSystem.Core.Bookings.BookingConstants;

namespace SettlementBookingSystem.Core.Bookings
{
    public class Appointment : Entity
    {
        internal Appointment(string name, WorkingTime time) : base()
        {
            Name = name;
            StartTime = time;
            EndTime = time.AddMinutes(AppointmentDuration - 1);
        }

        public string Name { get; }

        public WorkingTime StartTime { get; }

        public WorkingTime EndTime { get; }
    }
}
