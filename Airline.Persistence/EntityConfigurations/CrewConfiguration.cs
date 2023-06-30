using Airline.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airline.Persistence.EntityConfigurations;

public class CrewConfiguration : IEntityTypeConfiguration<Crew>
{
    public void Configure(EntityTypeBuilder<Crew> builder)
    {
        builder.HasKey(c => c.CrewId);
        builder.Property(c => c.Name).HasMaxLength(75);
        builder.HasMany(c => c.Members)
            .WithOne(cm => cm.CurrentCrew)
            .OnDelete(DeleteBehavior.SetNull);
    }
}