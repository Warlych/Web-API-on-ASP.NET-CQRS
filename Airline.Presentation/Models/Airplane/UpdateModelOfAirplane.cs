using Airline.Application.Core.Airplanes.Commands.Update;
using Airline.Application.Interfaces;
using AutoMapper;

namespace Airline.Presentation.Models.Airplane;

public class UpdateModelOfAirplane : IMappingTo<UpdateCommandOfAirplane>
{
    public required Guid AirplaneId { get; set; }
    public required string Name { get; set; }
    public required Guid ModelId { get; set; }
    public required Guid CurrentCrewId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateModelOfAirplane, UpdateCommandOfAirplane>().ReverseMap();
    }
}