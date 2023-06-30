using MediatR;

namespace Airline.Application.Core.Airplanes.Commands.Delete;

public class DeleteCommandOfAirplane : IRequest
{
    public required Guid AirplaneId { get; set; }
}