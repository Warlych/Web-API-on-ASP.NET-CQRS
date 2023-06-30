namespace Airline.Domain;

public class UsageAirdromeHistory
{
    public Guid AirplaneId { get; set; }
    public Guid AirdromeId { get; set; }

    public DateTime StartOfUse { get; set; }
    public DateTime EndOfUse { get; set; }
}
