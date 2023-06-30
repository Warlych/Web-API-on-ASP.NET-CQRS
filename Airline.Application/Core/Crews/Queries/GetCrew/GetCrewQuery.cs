using Airline.Application.Core.Crews.Queries.Model;
using MediatR;

namespace Airline.Application.Core.Crews.Queries.GetCrew;

public class GetCrewQuery : IRequest<CrewDetail>
{
    public required Guid CrewId { get; set; }
}