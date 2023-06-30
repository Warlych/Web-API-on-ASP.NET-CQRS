using Airline.Application.Core.Airplanes.Queries.Model;
using MediatR;

namespace Airline.Application.Core.Airplanes.Queries.GetAirplane;

public class GetAirplaneQuery : IRequest<AirplaneDetail>
{
    public required Guid AirplaneId { get; set; }
}