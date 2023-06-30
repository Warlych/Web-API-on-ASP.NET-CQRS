using Airline.Application.Interfaces;
using Airline.Domain;
using AutoMapper;
using MediatR;

namespace Airline.Application.Core.UsageAirdromeHistories.Commands.Create;

public class CreateCommandOfAirdromeHistory : IRequest<Guid>, IMappingTo<UsageAirdromeHistory>
{
    public required Guid AirdromeId { get; set; }
    public required Guid AirplaneId { get; set; }
    public required DateTime StartOfUse { get; set; }
    public required DateTime EndOfUse { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UsageAirdromeHistory, CreateCommandOfAirdromeHistory>().ReverseMap();
    }
}