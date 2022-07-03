namespace SettlementBookingSystem.Core.Bookings
{
    internal static class BookingConstants
    {
        /// <summary>
        /// Appointment Duration in minute.
        /// </summary>
        internal const int AppointmentDuration = 60;

        internal const int MinWorkingHour = 9;

        internal const int MaxWorkingHour = 17;

        internal static readonly WorkingTime LatestBookingTime = new(16, 0);

        internal static readonly WorkingTime EarliestBookingTime = new(9, 0);
    }
}
