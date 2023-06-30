using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using MediatR;

namespace Airline.Application.Core.Voyages.Commands.Delete;

public class DeleteCommandHandlerOfVoyage : IRequestHandler<DeleteCommandOfVoyage>
{
    private readonly IDataContext _context;

    public DeleteCommandHandlerOfVoyage(IDataContext context)
        => (_context) = (context);

    public async Task Handle(DeleteCommandOfVoyage request, CancellationToken token)
    {
        var voyage = await _context.Voyages
            .FindAsync(new object[] { request.VoyageId }, token);

        if (voyage == null)
            throw new NotFoundException(nameof(voyage), request.VoyageId);

        _context.Voyages.Remove(voyage);
        await _context.SaveChangesAsync(token);
    }
}