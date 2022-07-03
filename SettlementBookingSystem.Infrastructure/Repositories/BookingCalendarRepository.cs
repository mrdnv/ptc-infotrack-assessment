using SettlementBookingSystem.Core.Bookings;
using SettlementBookingSystem.Core.Common;
using System.Linq;

namespace SettlementBookingSystem.Infrastructure.Repositories
{
    public class BookingCalendarRepository : IRepository<BookingCalendar>
    {
        private readonly DataContext dataContext;

        public BookingCalendarRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public BookingCalendar Get()
        {
            var bookingCalendar = dataContext.BookingCalendars.FirstOrDefault();

            return bookingCalendar ?? new BookingCalendar();
        }

        public void Save(BookingCalendar aggregateRoot)
        {
            Upsert(aggregateRoot);

            foreach (var domainEvent in aggregateRoot.DomainEvents)
            {
                // Fire domain events after upsert successfully.
            }
        }

        private void Upsert(BookingCalendar aggregateRoot)
        {
            if (dataContext.BookingCalendars.Contains(aggregateRoot))
            {
                // Since We are storing data in memory. Calling update is not needed.
                return;
            }

            dataContext.BookingCalendars.Add(aggregateRoot);
        }
    }
}
