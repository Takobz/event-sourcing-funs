using EventSourcing.POC.Data.DataModels;
using Microsoft.EntityFrameworkCore;

namespace EventSourcing.POC.Data.DbContexts 
{

    public interface IEventSourcingDbContext
    {
        public DbSet<EventData> Events { get; set; }
        public Task SaveAsync();
    }

    public class EventSourcingDbContext(DbContextOptions<EventSourcingDbContext> options
    ) : DbContext(options), IEventSourcingDbContext
    {
        public DbSet<EventData> Events { get; set; }
        public async Task SaveAsync()
        {
            await base.SaveChangesAsync();
        }
    }
}