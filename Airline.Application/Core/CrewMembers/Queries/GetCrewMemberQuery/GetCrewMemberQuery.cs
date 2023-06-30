using Airline.Application.Core.CrewMembers.Queries.Model;
using MediatR;

namespace Airline.Application.Core.CrewMembers.Queries.GetCrewMemberQuery;

public class GetCrewMemberQuery : IRequest<CrewMemberDetail>
{
    public required Guid CrewMemberId { get; set; }
}