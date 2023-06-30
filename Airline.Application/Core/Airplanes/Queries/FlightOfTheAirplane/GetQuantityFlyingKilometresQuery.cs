using MediatR;

namespace Airline.Application.Core.Airplanes.Queries.FlightOfTheAirplane;

public class GetQuantityFlyingKilometresQuery : IRequest<Dictionary<string, double>>
{
    public Guid AirplaneId { get; set; }
}