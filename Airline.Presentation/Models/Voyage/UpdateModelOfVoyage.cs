using Airline.Application.Core.Voyages.Commands.Update;
using Airline.Application.Interfaces;
using AutoMapper;

namespace Airline.Presentation.Models.Voyage;

public class UpdateModelOfVoyage : IMappingTo<UpdateCommandOfVoyage>
{
    public required Guid VoyageId { get; set; }
    public required string Name { get; set; }
    public required string From { get; set; }
    public required string To { get; set; }
    public required DateTime FlightDate { get; set; }
    public required double FlightLength { get; set; }
    public required double TicketPrice { get; set; }
    public required double FlightTime { get; set; }
    public required Guid StartId { get; set; }
    public required Guid EndId { get; set; }
    public required Guid CurrentAirplaneId { get; set; }
    public required int SoldSeats { get; set; }
    public required int LeftSeats { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateModelOfVoyage, UpdateCommandOfVoyage>().ReverseMap();
    }
}