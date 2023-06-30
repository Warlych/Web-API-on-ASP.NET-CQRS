using Airline.Application.Interfaces;
using Airline.Domain;
using AutoMapper;
using MediatR;

namespace Airline.Application.Core.Airplanes.Commands.Create;

public class CreateCommandOfAirplane : IRequest<Guid>, IMappingTo<Airplane>
{
    public required string Name { get; set; }
    public required Guid ModelId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCommandOfAirplane, Airplane>().ReverseMap();
    }
}