using SettlementBookingSystem.Core.Common;

namespace SettlementBookingSystem.Core.Bookings
{
    public class BookingManager
    {
        private readonly IRepository<BookingCalendar> bookingCalendarRepository;

        public BookingManager(IRepository<BookingCalendar> bookingCalendarRepository)
        {
            this.bookingCalendarRepository = bookingCalendarRepository;
        }

        public Appointment AddAppointment(string name, string time)
        {
            var bookingCalendar = bookingCalendarRepository.Get();
            var appointment = bookingCalendar.AddNewAppointment(name, time);
            bookingCalendarRepository.Save(bookingCalendar);

            return appointment;
        }
    }
}
