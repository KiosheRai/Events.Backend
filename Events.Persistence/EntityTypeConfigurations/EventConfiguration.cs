using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Events.Domain;

namespace Events.Persistence.EntityTypeConfigurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(eve => eve.Id);
            builder.HasIndex(eve => eve.Id).IsUnique();
            builder.Property(eve => eve.Title).HasMaxLength(50);
            builder.Property(eve => eve.Address).HasMaxLength(50);
        }
    }
}
