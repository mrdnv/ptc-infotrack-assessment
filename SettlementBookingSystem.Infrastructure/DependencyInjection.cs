using Microsoft.Extensions.DependencyInjection;
using SettlementBookingSystem.Core.Bookings;
using SettlementBookingSystem.Core.Common;
using SettlementBookingSystem.Infrastructure.Repositories;

namespace SettlementBookingSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddSingleton<DataContext>()
                .AddTransient<IRepository<BookingCalendar>, BookingCalendarRepository>();

            return serviceCollection;
        }
    }
}
