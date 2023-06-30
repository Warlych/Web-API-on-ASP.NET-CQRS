using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Airdromes.Commands.Delete;

public class DeleteCommandHandlerOfAirdrome : IRequestHandler<DeleteCommandOfAirdrome>
{
    private readonly IDataContext _context;

    public DeleteCommandHandlerOfAirdrome(IDataContext context)
        => (_context) = (context);

    public async Task Handle(DeleteCommandOfAirdrome request, CancellationToken token)
    {
        var airdrome = await _context.Airdromes
            .FirstOrDefaultAsync(airdrome => airdrome.AirdromeId == request.AirdromeId, token);

        if (airdrome == null)
            throw new NotFoundException(nameof(airdrome), request.AirdromeId);

        _context.Airdromes.Remove(airdrome);
        await _context.SaveChangesAsync(token);
    }
}