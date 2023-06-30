using MediatR;

namespace Airline.Application.Core.Airplanes.Commands.Update;

public class UpdateCommandOfAirplane : IRequest<Guid>
{
    public required Guid AirplaneId { get; init; }
    public required string Name { get; init; }
    public required Guid ModelId { get; init; }
    public required Guid CurrentCrewId { get; init; }
}