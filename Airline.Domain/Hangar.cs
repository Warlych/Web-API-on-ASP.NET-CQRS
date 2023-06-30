namespace Airline.Domain;

public class Hangar
{
    public required Guid HangarId { get; set; }
    public required bool IsUsed { get; set; }
    public Guid? AirplaneId { get; set; }
    public Airplane? Airplane { get; set; }
    public Guid? CurrentAirdromeId { get; set; }
    public Airdrome? CurrentAirdrome { get; set; }
}

