using MediatR;

namespace Airline.Application.Core.Crews.Commands.Delete;

public class DeleteCommandOfCrew : IRequest
{
    public required Guid CrewId { get; set; }
}