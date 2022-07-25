using Events.Application.Interfaces;
using Events.Domain;
using Events.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Events.Persistence
{
    public class EventsDbContext : DbContext, IEventsDbContext
    {
        public DbSet<Event> Events { get; set; }

        public EventsDbContext(DbContextOptions<EventsDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EventConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
