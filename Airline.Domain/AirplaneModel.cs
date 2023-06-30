namespace Airline.Domain;

public class AirplaneModel
{
    public required Guid ModelId { get; set; }
    public required string ModelName { get; set; }
    public required int CrewCount { get; set; }
    public required int TotalSeats { get; set; }
    public required int RunwayLength { get; set; }
    public required int FuelTankSize { get; set; }
    public required int FuelConsumptionPerHour { get; set; }
    public List<Airplane> ModelInstance { get; set; }
    public List<Airdrome>? ServingAirdromes { get; set; }
}

