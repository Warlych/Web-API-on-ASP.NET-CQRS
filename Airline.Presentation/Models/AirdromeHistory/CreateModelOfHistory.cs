using Airline.Application.Core.UsageAirdromeHistories.Commands.Create;
using Airline.Application.Interfaces;
using AutoMapper;

namespace Airline.Presentation.Models.AirdromeHistory;

public class CreateModelOfHistory : IMappingTo<CreateCommandOfAirdromeHistory>
{
    public required Guid AirdromeId { get; set; }
    public required Guid AirplaneId { get; set; }
    public required DateTime StartOfUse { get; set; }
    public required DateTime EndOfUse { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateModelOfHistory, CreateCommandOfAirdromeHistory>().ReverseMap();
    }
}