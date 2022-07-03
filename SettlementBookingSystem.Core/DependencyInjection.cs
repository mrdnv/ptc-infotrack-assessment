using Microsoft.Extensions.DependencyInjection;
using SettlementBookingSystem.Core.Bookings;

namespace SettlementBookingSystem.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<BookingManager>();

            return serviceCollection;
        }
    }
}
