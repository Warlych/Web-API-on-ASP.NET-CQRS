using MediatR;

namespace Airline.Application.Core.CrewMembers.Commands.Update;

public class UpdateCommandOfCrewMember : IRequest<Guid>
{
    public required Guid CrewMemberId { get; set; }
    public required string FullName { get; set; }
    public required string PhoneNumber { get; set; }
    public required double Salary { get; set; }
    public required string JobTitle { get; set; }
    public required Guid CrewId { get; set; }
}