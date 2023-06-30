using Airline.Application.Core.Hangars.Commands.Update;
using Airline.Application.Interfaces;
using AutoMapper;

namespace Airline.Presentation.Models.Hangar;

public class UpdateModelOfHangar : IMappingTo<UpdateCommandOfHangar>
{
    public required Guid HangarId { get; set; }
    public required bool IsUsed { get; set; }
    public required Guid AirplaneId { get; set; }
    public required Guid CurrentAirdromeId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateModelOfHangar, UpdateCommandOfHangar>().ReverseMap();
    }
}