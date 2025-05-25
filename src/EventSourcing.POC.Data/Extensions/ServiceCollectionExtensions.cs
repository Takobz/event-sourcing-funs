using EventSourcing.POC.Data.DbContexts;
using EventSourcing.POC.Data.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EventSourcing.POC.Data.Extensions 
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEventSourcingPOCData(
            this IServiceCollection services,
            Func<EventSourcingPOCPostgresDataOptions> options)
        {
            var connectionString = PostgresConnectionString(options());
            services.AddDbContext<EventSourcingDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddTransient<IEventSourcingDbContext, EventSourcingDbContext>();

            return services;
        }

        private static string PostgresConnectionString(EventSourcingPOCPostgresDataOptions postgresOptions)
         => $"Host={postgresOptions.Host};Database={postgresOptions.Database};Username={postgresOptions.Username};Password={postgresOptions.Password}"; 
    }
}