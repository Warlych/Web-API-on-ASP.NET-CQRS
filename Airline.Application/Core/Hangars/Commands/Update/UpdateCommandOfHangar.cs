using MediatR;

namespace Airline.Application.Core.Hangars.Commands.Update;

public class UpdateCommandOfHangar : IRequest<Guid>
{
    public required Guid HangarId { get; set; }
    public required bool IsUsed { get; set; }
    public required Guid AirplaneId { get; set; }
    public required Guid CurrentAirdromeId { get; set; }
}