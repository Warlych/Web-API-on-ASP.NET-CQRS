using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Airline.Domain;

namespace Airline.Persistence.EntityConfigurations
{
    public class AirplaneModelConfiguration : IEntityTypeConfiguration<AirplaneModel>
    {
        public void Configure(EntityTypeBuilder<AirplaneModel> builder)
        {
            builder.HasKey(a => a.ModelId);
            builder.Property(a => a.ModelName).HasMaxLength(50).IsRequired();
            builder.HasMany(m => m.ModelInstance)
                .WithOne(a => a.Model)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
