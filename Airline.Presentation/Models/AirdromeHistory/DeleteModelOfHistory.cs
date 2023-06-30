using Airline.Application.Core.UsageAirdromeHistories.Commands.Delete;
using Airline.Application.Interfaces;
using AutoMapper;

namespace Airline.Presentation.Models.AirdromeHistory;

public class DeleteModelOfHistory : IMappingTo<DeleteCommandOfAirdromeHistory>
{
    public required Guid AirdromeId { get; set; }
    public required Guid AirplaneId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DeleteModelOfHistory, DeleteCommandOfAirdromeHistory>().ReverseMap();
    }
}