using Airline.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airline.Persistence.EntityConfigurations;

public class CrewMemberConfiguration : IEntityTypeConfiguration<CrewMember>
{
    public void Configure(EntityTypeBuilder<CrewMember> builder)
    {
        builder.HasKey(m => m.CrewMemberId);
        builder.Property(m => m.FullName).HasMaxLength(100).IsRequired();
        builder.Property(m => m.JobTitle).HasMaxLength(65).IsRequired();
    }
}