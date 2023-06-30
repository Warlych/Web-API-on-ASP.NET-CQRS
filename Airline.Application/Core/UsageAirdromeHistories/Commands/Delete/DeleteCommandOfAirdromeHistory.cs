using MediatR;

namespace Airline.Application.Core.UsageAirdromeHistories.Commands.Delete;

public class DeleteCommandOfAirdromeHistory : IRequest
{
    public required Guid AirdromeId { get; set; }
    public required Guid AirplaneId { get; set; }
}