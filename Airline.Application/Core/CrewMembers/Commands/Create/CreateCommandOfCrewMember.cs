using Airline.Application.Interfaces;
using Airline.Domain;
using AutoMapper;
using MediatR;

namespace Airline.Application.Core.CrewMembers.Commands.Create;

public class CreateCommandOfCrewMember : IRequest<Guid>, IMappingTo<CrewMember>
{
    public required string FullName { get; set; }
    public required string PhoneNumber { get; set; }
    public required double Salary { get; set; }
    public required string JobTitle { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCommandOfCrewMember, CrewMember>().ReverseMap();
    }
}