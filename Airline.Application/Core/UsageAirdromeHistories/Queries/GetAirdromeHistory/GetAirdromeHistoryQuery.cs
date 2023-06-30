using Airline.Application.Core.UsageAirdromeHistories.Queries.Model;
using MediatR;

namespace Airline.Application.Core.UsageAirdromeHistories.Queries.GetAirdromeHistories;

public class GetAirdromeHistoryQuery : IRequest<AirdromeHistoryDetail[]>
{
    public required Guid AirdromeId { get; set; }
}