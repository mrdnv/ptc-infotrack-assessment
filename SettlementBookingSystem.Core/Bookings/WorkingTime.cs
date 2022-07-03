using SettlementBookingSystem.Core.Common;
using SettlementBookingSystem.Core.Common.Exceptions;
using System;
using static SettlementBookingSystem.Core.Bookings.BookingConstants;

namespace SettlementBookingSystem.Core.Bookings
{
    public record WorkingTime : IValueObject
    {
        public WorkingTime(int hour, int minute)
        {
            Validate(hour, minute);

            Hour = hour;
            Minute = minute;
            TrueValue = new TimeSpan(hour, minute, 0);
        }

        public WorkingTime(string workingTime)
        {
            var workingTimeComponents = workingTime?.Split(':');

            if (workingTimeComponents is null || workingTimeComponents.Length < 2)
            {
                throw new ValidationException($"{workingTime} is not a valid Time.");
            }

            var isValidHour = int.TryParse(workingTimeComponents[0], out var hour);

            if (!isValidHour)
            {
                throw new ValidationException($"{hour} is not a valid Hour.");
            }

            var isValidMinute = int.TryParse(workingTimeComponents[1], out var minute);

            if (!isValidMinute)
            {
                throw new ValidationException($"{minute} is not a valid Minute.");
            }

            Validate(hour, minute);

            Hour = hour;
            Minute = minute;
            TrueValue = new TimeSpan(hour, minute, 0);
        }

        private TimeSpan TrueValue { get; }

        public int Hour { get; }

        public int Minute { get; }

        public override string ToString()
        {
            return $"{Hour:00}:{Minute:00}";
        }

        public WorkingTime AddMinutes(int minutes)
        {
            var newTime = TrueValue.Add(TimeSpan.FromMinutes(minutes));

            return new(newTime.Hours, newTime.Minutes);
        }

        private static void Validate(int hour, int minute)
        {
            if (hour < MinWorkingHour || hour > MaxWorkingHour)
            {
                throw new ValidationException($"{hour} is not a valid Working Hour.");
            }

            if (minute < 0 || minute > 59)
            {
                throw new ValidationException($"{minute} is not a valid Minute.");
            }

            if (hour == MaxWorkingHour && minute > 0)
            {
                throw new ValidationException($"{hour:00}:{minute:00} is not a valid Working Time.");
            }
        }

        public static implicit operator WorkingTime(string time) => new(time);

        public static bool operator <(WorkingTime left, WorkingTime right)
        {
            return left.TrueValue < right.TrueValue;
        }

        public static bool operator <=(WorkingTime left, WorkingTime right)
        {
            return left.TrueValue <= right.TrueValue;
        }

        public static bool operator >(WorkingTime left, WorkingTime right)
        {
            return left.TrueValue > right.TrueValue;
        }

        public static bool operator >=(WorkingTime left, WorkingTime right)
        {
            return left.TrueValue >= right.TrueValue;
        }
    }
}
