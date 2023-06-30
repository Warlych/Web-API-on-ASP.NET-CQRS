using Airline.Application.Core.Airdromes.Queries.Model;
using MediatR;

namespace Airline.Application.Core.Airdromes.Queries.GetAirdrome;

public class GetAirdromeQuery : IRequest<AirdromeDetail>
{
    public required Guid AirdromeId { get; set; }
}