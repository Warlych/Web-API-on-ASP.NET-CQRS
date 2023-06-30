using Airline.Application.Core.CrewMembers.Commands.Create;
using Airline.Application.Interfaces;
using AutoMapper;

namespace Airline.Presentation.Models.CrewMember;

public class CreateModelOfCrewMember : IMappingTo<CreateCommandOfCrewMember>
{
    public required string FullName { get; set; }
    public required string PhoneNumber { get; set; }
    public required double Salary { get; set; }
    public required string JobTitle { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateModelOfCrewMember, CreateCommandOfCrewMember>().ReverseMap();
    }
}