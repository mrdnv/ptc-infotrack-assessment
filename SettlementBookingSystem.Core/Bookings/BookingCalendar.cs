using SettlementBookingSystem.Core.Bookings.Events;
using SettlementBookingSystem.Core.Common;
using SettlementBookingSystem.Core.Common.Exceptions;
using System.Collections.Generic;
using System.Linq;
using static SettlementBookingSystem.Core.Bookings.BookingConstants;

namespace SettlementBookingSystem.Core.Bookings
{
    public class BookingCalendar : AggregateRoot
    {
        public BookingCalendar() : base()
        {
            _appointments = new HashSet<Appointment>();
        }

        private readonly HashSet<Appointment> _appointments;
        public IEnumerable<Appointment> Appointments => _appointments;

        /// <summary>
        /// Add a new appointment to the booking calendar.
        /// </summary>
        /// <param name="name">Name of the booking person.</param>
        /// <param name="time">Time when the appointment starts.</param>
        /// <returns></returns>
        public Appointment AddNewAppointment(string name, string time)
        {
            if (_appointments.Count == LimitNumberOfAppointments)
            {
                throw new DuplicationException("Cannot add new appointment. Booking calendar for today is full.");
            }

            WorkingTime bookingTime = time;

            if (bookingTime < EarliestBookingTime || bookingTime > LatestBookingTime)
            {
                throw new ValidationException($"Latest booking time is {LatestBookingTime}.");
            }

            var bookingTimeEnd = bookingTime.AddMinutes(AppointmentDuration - 1);

            var overlappedAppointment = _appointments.FirstOrDefault(appointment =>
                appointment.StartTime <= bookingTimeEnd && appointment.EndTime >= bookingTime);

            if (overlappedAppointment is not null)
            {
                throw new DuplicationException($"Appointment from {time} to {bookingTimeEnd} is already reserved. ({overlappedAppointment.StartTime} - {overlappedAppointment.EndTime})");
            }

            var appointment = new Appointment(name, bookingTime);
            _appointments.Add(appointment);
            AddEvent(new AppointmentAdded(appointment));

            return appointment;
        }
    }
}
