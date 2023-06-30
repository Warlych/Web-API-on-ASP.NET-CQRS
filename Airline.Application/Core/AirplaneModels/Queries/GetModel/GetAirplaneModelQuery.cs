using Airline.Application.Core.AirplaneModels.Queries.Model;
using MediatR;

namespace Airline.Application.Core.AirplaneModels.Queries.GetModel;

public class GetAirplaneModelQuery : IRequest<AirplaneModelDetail>
{
    public Guid ModelId { get; set; }
}