using Microsoft.Extensions.DependencyInjection;


namespace Events.Application
{
    public static class DependencynInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}
