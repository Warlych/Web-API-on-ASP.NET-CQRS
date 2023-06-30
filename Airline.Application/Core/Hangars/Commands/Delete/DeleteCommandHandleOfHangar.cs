using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Hangars.Commands.Delete;

public class DeleteCommandHandleOfHangar : IRequestHandler<DeleteCommandOfHangar>
{
    private readonly IDataContext _context;

    public DeleteCommandHandleOfHangar(IDataContext context)
        => (_context) = (context);

    public async Task Handle(DeleteCommandOfHangar request, CancellationToken token)
    {
        var hangar = await _context.Hangars
            .FirstOrDefaultAsync(hangar => hangar.HangarId == request.HangarId);

        if (hangar == null)
            throw new NotFoundException(nameof(hangar), request.HangarId);

        _context.Hangars.Remove(hangar);
        await _context.SaveChangesAsync(token);
    }
}