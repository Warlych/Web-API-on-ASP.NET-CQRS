namespace Airline.Domain;

public class Airplane
{
    public required Guid AirplaneId { get; set; }
    public required string Name { get; set; }
    public required Guid ModelId { get; set; }
    public required AirplaneModel Model { get; set; }

    public Guid? CurrentCrewId { get; set; }
    public Crew? CurrentCrew { get; set; }
    public List<Voyage>? Voyages { get; set; }
    public List<Airdrome>? UsedAirdromes { get; set; }
}

