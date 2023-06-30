using Airline.Application.Interfaces;
using Airline.Domain;
using AutoMapper;

namespace Airline.Application.Core.Hangars.Queries.Model;

public class HangarDetail : IMappingTo<Hangar>
{
    public required Guid HangarId { get; set; }
    public required bool IsUsed { get; set; }
    public required Guid AirplaneId { get; set; }
    public required Guid CurrentAirdromeId { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<HangarDetail, Hangar>().ReverseMap();
    }
}