using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Airline.Domain;

namespace Airline.Persistence.EntityConfigurations
{
    public class AirplaneConfiguration : IEntityTypeConfiguration<Airplane>
    {
        public void Configure(EntityTypeBuilder<Airplane> builder)
        {
            builder.HasKey(a => a.AirplaneId);
            builder.Property(a => a.Name).HasMaxLength(50).IsRequired();
        }
    }
}
