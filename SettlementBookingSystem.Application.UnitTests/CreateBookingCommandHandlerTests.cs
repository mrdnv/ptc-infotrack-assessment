using FluentAssertions;
using Moq;
using SettlementBookingSystem.Application.Bookings.Commands;
using SettlementBookingSystem.Core.Bookings;
using SettlementBookingSystem.Core.Common;
using SettlementBookingSystem.Core.Common.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SettlementBookingSystem.Application.UnitTests
{
    public class CreateBookingCommandHandlerTests
    {
        private readonly Mock<IRepository<BookingCalendar>> bookingCalendarRepository = new();
        private readonly BookingManager bookingManager;

        private BookingCalendar BookingCalendar { get; }

        public CreateBookingCommandHandlerTests()
        {
            BookingCalendar = new BookingCalendar();
            BookingCalendar.AddNewAppointment("First", "11:00");
            BookingCalendar.AddNewAppointment("Second", "12:00");
            BookingCalendar.AddNewAppointment("Third", "13:00");

            bookingCalendarRepository.Setup(repo => repo.Get())
                .Returns(BookingCalendar);

            bookingManager = new BookingManager(bookingCalendarRepository.Object);
        }

        [Fact]
        public async Task GivenValidBookingTime_WhenNoConflictingBookings_ThenBookingIsAccepted()
        {
            var command = new CreateBookingCommand
            {
                Name = "test",
                BookingTime = "09:15",
            };

            var handler = new CreateBookingCommandHandler(bookingManager);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Should().NotBeNull();
            result.BookingId.Should().NotBeEmpty();
        }

        [Fact]
        public void GivenOutOfHoursBookingTime_WhenBooking_ThenValidationFails()
        {
            var command = new CreateBookingCommand
            {
                Name = "test",
                BookingTime = "00:00",
            };

            var handler = new CreateBookingCommandHandler(bookingManager);

            Func<Task> act = async () => await handler.Handle(command, CancellationToken.None);

            act.Should().Throw<ValidationException>();
        }

        [Fact]
        public void GivenValidBookingTime_WhenBookingIsFull_ThenConflictThrown()
        {
            var command = new CreateBookingCommand
            {
                Name = "test",
                BookingTime = "10:15",
            };

            var handler = new CreateBookingCommandHandler(bookingManager);

            Func<Task> act = async () => await handler.Handle(command, CancellationToken.None);

            act.Should().Throw<DuplicationException>();
        }
    }
}
