namespace Airline.Domain;

public class ModelToAirdrome
{
    public required Guid AirdromeId { get; set; }
    public required Airdrome Airdrome { get; set; }
    public required Guid ModelId { get; set; }
    public required AirplaneModel Model { get; set; }
}