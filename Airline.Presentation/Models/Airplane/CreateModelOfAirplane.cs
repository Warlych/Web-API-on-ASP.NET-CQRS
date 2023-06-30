using Airline.Application.Core.Airplanes.Commands.Create;
using Airline.Application.Interfaces;
using AutoMapper;

namespace Airline.Presentation.Models.Airplane;

public class CreateModelOfAirplane : IMappingTo<CreateCommandOfAirplane>
{
    public required string Name { get; set; }
    public required Guid ModelId { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCommandOfAirplane, CreateModelOfAirplane>().ReverseMap();
    }
}