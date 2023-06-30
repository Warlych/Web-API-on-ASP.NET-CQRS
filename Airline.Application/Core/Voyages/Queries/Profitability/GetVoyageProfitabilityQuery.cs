using MediatR;

namespace Airline.Application.Core.Voyages.Queries.Profitability;

public class GetVoyageProfitabilityQuery : IRequest<double>
{
    public required Guid VoyageId { get; set; }
}