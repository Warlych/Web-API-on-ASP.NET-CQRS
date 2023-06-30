using Airline.Application.Core.AirplaneModels.Queries.Model;
using Airline.Application.Core.Hangars.Queries.Model;
using Airline.Application.Interfaces;
using Airline.Domain;
using AutoMapper;

namespace Airline.Application.Core.Airdromes.Queries.Model;

public class AirdromeDetail : IMappingTo<Airdrome>
{
    public required Guid AirdromeId { get; set; }
    public required string Name { get; set; }
    public required double DowntimeCostPerHour { get; set; }
    public required List<AirplaneModelDetail> Models { get; set; }
    public required List<HangarDetail> Hangars { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<AirdromeDetail, Airdrome>().ReverseMap();
    }
}