using Airline.Domain;
using Airline.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Airline.Application.Interfaces;

namespace Airline.Persistence;

public class DataContext : DbContext, IDataContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new AirplaneModelConfiguration());
        builder.ApplyConfiguration(new AirplaneConfiguration());
        builder.ApplyConfiguration(new HangarConfiguration());
        builder.ApplyConfiguration(new AirdromeConfiguration());
        builder.ApplyConfiguration(new VoyageConfiguration());
        builder.ApplyConfiguration(new CrewConfiguration());
        builder.ApplyConfiguration(new CrewMemberConfiguration());

        builder.Entity<AirplaneModel>()
            .HasMany(a => a.ServingAirdromes)
            .WithMany(d => d.Models)
            .UsingEntity<ModelToAirdrome>();

        builder.Entity<Airplane>()
            .HasMany(a => a.UsedAirdromes)
            .WithMany(d => d.ServicedAirplanes)
            .UsingEntity<UsageAirdromeHistory>();

        base.OnModelCreating(builder);
    }

    public DbSet<Airplane> Airplanes { get; set; }
    public DbSet<AirplaneModel> AirplaneModels { get; set; }
    public DbSet<Airdrome> Airdromes { get; set; }
    public DbSet<Hangar> Hangars { get; set; }
    public DbSet<Voyage> Voyages { get; set; }
    public DbSet<CrewMember> CrewMembers { get; set; }
    public DbSet<Crew> Crews { get; set; }
    public DbSet<ModelToAirdrome> ModelsToAirdromes { get; set; }
    public DbSet<UsageAirdromeHistory> AirdromeHistories { get; set; }
}