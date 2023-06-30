using Airline.Application.Core.Airplanes.Queries.Model;
using MediatR;

namespace Airline.Application.Core.Airplanes.Queries.GetAirplanes;

public class GetAirplanesQuery : IRequest<AirplaneDetail[]>
{
    
}