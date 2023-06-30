using Airline.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airline.Persistence.EntityConfigurations
{
    public class HangarConfiguration : IEntityTypeConfiguration<Hangar>
    {
        public void Configure(EntityTypeBuilder<Hangar> builder)
        {
            builder.HasKey(h => h.HangarId);
            builder.Property(h => h.IsUsed).HasDefaultValue(false);
        }
    }
}
