using Airline.Application.Core.CrewMembers.Queries.Model;
using Airline.Application.Interfaces;
using Airline.Domain;
using AutoMapper;

namespace Airline.Application.Core.Crews.Queries.Model;

public class CrewDetail : IMappingTo<Crew>
{
    public required Guid CrewId { get; set; }
    public required string Name { get; set; }
    public required List<CrewMemberDetail> CrewMembers { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CrewDetail, Crew>().ReverseMap();
    }
}