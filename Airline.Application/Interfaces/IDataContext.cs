using Airline.Domain;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Interfaces;

public interface IDataContext
{
    DbSet<Airplane> Airplanes { get; set; }
    DbSet<AirplaneModel> AirplaneModels { get; set; }
    DbSet<Airdrome> Airdromes { get; set; }
    DbSet<Hangar> Hangars { get; set; }
    DbSet<Voyage> Voyages { get; set; }
    DbSet<CrewMember> CrewMembers { get; set; }
    DbSet<Crew> Crews { get; set; }
    DbSet<ModelToAirdrome> ModelsToAirdromes { get; set; }
    DbSet<UsageAirdromeHistory> AirdromeHistories { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}