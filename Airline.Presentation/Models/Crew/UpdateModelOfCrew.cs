using Airline.Application.Core.Crews.Commands.Update;
using Airline.Application.Interfaces;
using AutoMapper;

namespace Airline.Presentation.Models.Crew;

public class UpdateModelOfCrew : IMappingTo<UpdateCommandOfCrew>
{
    public required Guid CrewId { get; set; }
    public required string Name { get; set; }
    public List<Guid> Members { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateCommandOfCrew, UpdateModelOfCrew>().ReverseMap();
    }
}