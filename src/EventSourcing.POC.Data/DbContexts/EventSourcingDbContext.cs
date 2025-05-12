using EventSourcing.POC.Data.DataModels;
using Microsoft.EntityFrameworkCore;

namespace EventSourcing.POC.Data.DbContexts 
{
    public class EventSourcingDbContext(DbContextOptions<EventSourcingDbContext> options) : DbContext(options)
    {
        public DbSet<EventData> Events { get; set; }
    }
}