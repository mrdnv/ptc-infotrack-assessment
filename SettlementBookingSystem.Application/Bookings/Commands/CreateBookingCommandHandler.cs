using MediatR;
using SettlementBookingSystem.Application.Bookings.Dtos;
using SettlementBookingSystem.Core.Bookings;
using System.Threading;
using System.Threading.Tasks;

namespace SettlementBookingSystem.Application.Bookings.Commands
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, BookingDto>
    {
        private readonly BookingManager bookingManager;

        public CreateBookingCommandHandler(BookingManager bookingManager)
        {
            this.bookingManager = bookingManager;
        }

        public Task<BookingDto> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var appointment = bookingManager.AddAppointment(request.Name, request.BookingTime);
            var bookingDto = new BookingDto(appointment.Id);

            return Task.FromResult(bookingDto);
        }
    }
}
