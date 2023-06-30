using Airline.Application.Core.CrewMembers.Commands.Update;
using Airline.Application.Interfaces;
using AutoMapper;

namespace Airline.Presentation.Models.CrewMember;

public class UpdateModelOfCrewMember : IMappingTo<UpdateCommandOfCrewMember>
{
    public required Guid CrewMemberId { get; set; }
    public required string FullName { get; set; }
    public required string PhoneNumber { get; set; }
    public required double Salary { get; set; }
    public required string JobTitle { get; set; }
    public required Guid CrewId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateCommandOfCrewMember, UpdateModelOfCrewMember>().ReverseMap();
    }
}