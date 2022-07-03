using SettlementBookingSystem.Core.Bookings;
using System.Collections.Generic;

namespace SettlementBookingSystem.Infrastructure
{
    public class DataContext
    {
        public DataContext()
        {
            BookingCalendars = new HashSet<BookingCalendar>();
        }

        public HashSet<BookingCalendar> BookingCalendars { get; set; }
    }
}