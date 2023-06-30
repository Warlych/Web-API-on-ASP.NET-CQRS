using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Airline.Domain;

namespace Airline.Persistence.EntityConfigurations
{
    public class VoyageConfiguration : IEntityTypeConfiguration<Voyage>
    {
        public void Configure(EntityTypeBuilder<Voyage> builder)
        {
            builder.HasKey(v => v.VoyageId);
            builder.Property(v => v.Name).HasMaxLength(50).IsRequired();
        }
    }
}
