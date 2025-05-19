using EventSourcing.POC.Data.DataModels;
using Microsoft.EntityFrameworkCore;

namespace EventSourcing.POC.Data.DbContexts 
{

    public interface IEventSourcingDbContext
    {
        public DbSet<EventData> Events { get; set; }
    }

    public class EventSourcingDbContext(DbContextOptions<EventSourcingDbContext> options
    ) : DbContext(options), IEventSourcingDbContext
    {
        public DbSet<EventData> Events { get; set; }
    }
}