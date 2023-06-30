using MediatR;

namespace Airline.Application.Core.Crews.Commands.Create;

public class CreateCommandOfCrew : IRequest<Guid>
{
    public required string Name { get; set; }
}