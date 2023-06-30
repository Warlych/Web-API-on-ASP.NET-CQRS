using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Airline.Domain;

namespace Airline.Persistence.EntityConfigurations
{
    public class AirdromeConfiguration : IEntityTypeConfiguration<Airdrome>
    {
        public void Configure(EntityTypeBuilder<Airdrome> builder)
        {
            builder.HasKey(a => a.AirdromeId);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(50);
            
            builder.HasMany(a => a.Hangars)
                .WithOne(h => h.CurrentAirdrome)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
