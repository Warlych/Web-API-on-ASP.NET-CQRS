using Airline.Application.Core.Hangars.Commands.Create;
using Airline.Application.Interfaces;
using AutoMapper;

namespace Airline.Presentation.Models.Hangar;

public class CreateModelOfHangar : IMappingTo<CreateCommandOfHangar>
{
    public required bool IsUsed { get; set; }
    public required Guid CurrentAirdromeId { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCommandOfHangar, CreateModelOfHangar>().ReverseMap();
    }
}