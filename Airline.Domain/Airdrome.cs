namespace Airline.Domain;

public class Airdrome
{
    public required Guid AirdromeId { get; set; }
    public required string Name { get; set; }
    public List<Hangar>? Hangars { get; set; }
    public List<AirplaneModel>? Models { get; set; }
    public List<Airplane>? ServicedAirplanes { get; set; }
    public required double DowntimeCostPerHour { get; set; }
    
}
