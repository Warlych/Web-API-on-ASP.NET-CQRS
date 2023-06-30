using Airline.Application.Interfaces;
using Airline.Domain;
using AutoMapper;
using MediatR;

namespace Airline.Application.Core.Voyages.Commands.Create;

public class CreateCommandOfVoyage : IRequest<Guid>, IMappingTo<Voyage>
{
    public required string Name { get; set; }
    public required string From { get; set; }
    public required string To { get; set; }
    public required DateTime FlightDate { get; set; }
    public required double FlightLength { get; set; }
    public required double TicketPrice { get; set; }
    public required double FlightTime { get; set; }
    public required Guid StartId { get; set; }
    public required Guid EndId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Voyage, CreateCommandOfVoyage>().ReverseMap();
    }
}