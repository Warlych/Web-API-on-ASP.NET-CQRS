using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.CrewMembers.Commands.Delete;

public class DeleteCommandHandlerOfCrewMember : IRequestHandler<DeleteCommandOfCrewMember>
{
    private readonly IDataContext _context;

    public DeleteCommandHandlerOfCrewMember(IDataContext context)
        => (_context) = (context);

    public async Task Handle(DeleteCommandOfCrewMember request, CancellationToken token)
    {
        var member = await _context.CrewMembers
            .FirstOrDefaultAsync(member => member.CrewMemberId == request.CrewMemberId, token);

        if (member == null)
            throw new NotFoundException(nameof(member), request.CrewMemberId);

        _context.CrewMembers.Remove(member);
        await _context.SaveChangesAsync(token);
    }
}