using MediatR;
using SettlementBookingSystem.Application.Bookings.Dtos;
using SettlementBookingSystem.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SettlementBookingSystem.Application.Bookings.Queries
{
    public class GetAllBookingsQueryHandler : IRequestHandler<GetAllBookingsQuery, IEnumerable<BookingDetailsDto>>
    {
        private readonly DataContext dataContext;

        public GetAllBookingsQueryHandler(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public Task<IEnumerable<BookingDetailsDto>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
        {
            var bookings = dataContext.BookingCalendars.FirstOrDefault()?
                .Appointments
                .OrderBy(appointment => appointment.StartTime)
                .Select(appointment => new BookingDetailsDto
                {
                    BookingId = appointment.Id,
                    From = appointment.StartTime.ToString(),
                    To = appointment.EndTime.ToString(),
                    Name = appointment.Name
                }) ?? Enumerable.Empty<BookingDetailsDto>();

            return Task.FromResult(bookings);
        }
    }
}
