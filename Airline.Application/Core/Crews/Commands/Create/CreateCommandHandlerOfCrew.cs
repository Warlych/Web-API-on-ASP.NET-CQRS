using Airline.Application.Interfaces;
using Airline.Domain;
using MediatR;

namespace Airline.Application.Core.Crews.Commands.Create;

public class CreateCommandHandlerOfCrew : IRequestHandler<CreateCommandOfCrew, Guid>
{
    private readonly IDataContext _context;

    public CreateCommandHandlerOfCrew(IDataContext context)
        => (_context) = (context);

    public async Task<Guid> Handle(CreateCommandOfCrew request, CancellationToken token)
    {
        var crew = new Crew()
        {
            CrewId = Guid.NewGuid(),
            Name = request.Name
        };

        await _context.Crews.AddAsync(crew, token);
        await _context.SaveChangesAsync(token);

        return crew.CrewId;
    }
}