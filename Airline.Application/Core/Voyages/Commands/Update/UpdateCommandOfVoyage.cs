using MediatR;

namespace Airline.Application.Core.Voyages.Commands.Update;

public class UpdateCommandOfVoyage : IRequest<Guid>
{
    public required Guid VoyageId { get; set; }
    public required string Name { get; set; }
    public required string From { get; set; }
    public required string To { get; set; }
    public required double FlightLength { get; set; }
    public required double TicketPrice { get; set; }
    public required double FlightTime { get; set; }
    public required Guid StartId { get; set; }
    public required Guid EndId { get; set; }
    public required DateTime FlightDate { get; set; }
    public required Guid CurrentAirplaneId { get; set; }
    public required int SoldSeats { get; set; }
    public required int LeftSeats { get; set; }
}