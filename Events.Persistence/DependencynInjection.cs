using Events.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Events.Persistence
{
    public static class DependencynInjection
    {
        public static IServiceCollection AppPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<EventsDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IEventsDbContext>(provider =>
                provider.GetService<EventsDbContext>());
            return services;
        }
    }
}
