using MediatR;

namespace Airline.Application.Core.Voyages.Queries.Occupancy;

public class GetVoyageOccupancyQuery : IRequest<double>
{
    public required Guid VoyageId { get; set; }
}