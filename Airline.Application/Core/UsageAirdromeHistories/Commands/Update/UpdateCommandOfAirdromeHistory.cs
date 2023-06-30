using MediatR;

namespace Airline.Application.Core.UsageAirdromeHistories.Commands.Update;

public class UpdateCommandOfAirdromeHistory : IRequest<Guid>
{
    public required Guid AirdromeId { get; set; }
    public required Guid AirplaneId { get; set; }
    public required DateTime StartOfUse { get; set; }
    public required DateTime EndOfUse { get; set; }
}