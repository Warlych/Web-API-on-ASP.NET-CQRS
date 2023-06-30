using MediatR;

namespace Airline.Application.Core.Crews.Commands.Update;

public class UpdateCommandOfCrew : IRequest<Guid>
{
    public required Guid CrewId { get; set; }
    public required string Name { get; set; }
    public List<Guid> Members { get; set; }
}