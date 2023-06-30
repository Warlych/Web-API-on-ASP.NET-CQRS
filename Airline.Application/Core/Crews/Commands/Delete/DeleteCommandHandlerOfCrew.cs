using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Crews.Commands.Delete;

public class DeleteCommandHandlerOfCrew : IRequestHandler<DeleteCommandOfCrew>
{
    private readonly IDataContext _context;

    public DeleteCommandHandlerOfCrew(IDataContext context)
        => (_context) = (context);

    public async Task Handle(DeleteCommandOfCrew request, CancellationToken token)
    {
        var crew = await _context.Crews.FirstOrDefaultAsync(crew => crew.CrewId == request.CrewId, token);

        if (crew == null)
            throw new NotFoundException(nameof(crew), request.CrewId);

        _context.Crews.Remove(crew);
        await _context.SaveChangesAsync(token);
    }
}