using MediatR;
using SettlementBookingSystem.Application.Bookings.Dtos;
using System.Collections.Generic;

namespace SettlementBookingSystem.Application.Bookings.Queries
{
    public record GetAllBookingsQuery : IRequest<IEnumerable<BookingDetailsDto>>
    {
    }
}
