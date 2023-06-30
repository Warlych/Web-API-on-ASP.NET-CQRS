using Airline.Application.Interfaces;
using Airline.Domain;
using AutoMapper;

namespace Airline.Application.Core.UsageAirdromeHistories.Queries.Model;

public class AirdromeHistoryDetail : IMappingTo<UsageAirdromeHistory>
{
    public required Guid AirdromeId { get; set; }
    public required Guid AirplaneId { get; set; }
    public required DateTime StartOfUse { get; set; }
    public required DateTime EndOfUse { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UsageAirdromeHistory, AirdromeHistoryDetail>().ReverseMap();
    }
}
    