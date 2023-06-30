using Airline.Application.Interfaces;
using Airline.Domain;
using AutoMapper;
using MediatR;

namespace Airline.Application.Core.Hangars.Commands.Create;

public class CreateCommandOfHangar : IRequest<Guid>, IMappingTo<Hangar>
{
    public required bool IsUsed { get; set; }
    public required Guid CurrentAirdromeId { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCommandOfHangar, Hangar>().ReverseMap();
    }
}