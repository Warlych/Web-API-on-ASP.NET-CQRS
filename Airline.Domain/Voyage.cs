namespace Airline.Domain;

public class Voyage
{
    public required Guid VoyageId { get; set; }
    public required string Name { get; set; }
    public required string From { get; set; }
    public required string To { get; set; }
    public required double FlightLength { get; set; }
    public required double TicketPrice { get; set; }
    
    public required double FlightTime { get; set; }
    
    public required Guid StartId { get; set; }
    public required Airdrome Start { get; set; }

    public required Guid EndId { get; set; }
    public required Airdrome End { get; set; }
    
    public DateTime? FlightDate { get; set; }

    public Guid? CurrentAirplaneId { get; set; }
    public Airplane? CurrentAirplane { get; set; }

    public int? SoldSeats { get; set; }
    public int? LeftSeats { get; set; }
}
