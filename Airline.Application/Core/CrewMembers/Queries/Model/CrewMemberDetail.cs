using Airline.Application.Interfaces;
using Airline.Domain;
using AutoMapper;

namespace Airline.Application.Core.CrewMembers.Queries.Model;

public class CrewMemberDetail : IMappingTo<CrewMember>
{
    public required Guid CrewMemberId { get; set; }
    public required string FullName { get; set; }
    public required string PhoneNumber { get; set; }
    public required double Salary { get; set; }
    public required string JobTitle { get; set; }
    public required Guid CrewId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CrewMemberDetail, CrewMember>().ReverseMap();
    }
}