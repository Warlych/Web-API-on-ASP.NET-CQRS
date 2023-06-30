using MediatR;

namespace Airline.Application.Core.CrewMembers.Commands.Delete;

public class DeleteCommandOfCrewMember : IRequest
{
    public required Guid CrewMemberId { get; set; }
}