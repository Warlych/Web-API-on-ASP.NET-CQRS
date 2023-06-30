using Airline.Application.Core.Voyages.Queries.Model;
using MediatR;

namespace Airline.Application.Core.Voyages.Queries.GetVoyage;

public class GetVoyageQuery : IRequest<VoyageDetail>
{
    public required Guid VoyageId { get; set; }
}