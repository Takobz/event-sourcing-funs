using EventSourcing.POC.Domain.Interfaces;
using EventSourcing.POC.Infrastructure.Helpers;
using EventSourcing.POC.Infrastructure.Repositories;
using EventSourcing.POC.Infrastructure.Store;
using Microsoft.Extensions.DependencyInjection;

namespace EventSourcing.POC.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IEventStore, EventStore>();
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddInfrastructureHelpers(this IServiceCollection services)
        {
            services.AddTransient<IJSONDataSerializer, JSONDataSerializer>();
            return services;
        }
    }    
}