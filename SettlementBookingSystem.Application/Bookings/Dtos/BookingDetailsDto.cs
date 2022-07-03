using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettlementBookingSystem.Application.Bookings.Dtos
{
    public class BookingDetailsDto
    {
        public Guid BookingId { get; set; }

        public string From { get; set; }

        public string To { get; set; }
        
        public string Name { get; set; }
    }
}
