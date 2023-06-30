using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.CrewMembers.Commands.Update;

public class UpdateCommandHandlerOfCrewMember : IRequestHandler<UpdateCommandOfCrewMember, Guid>
{
    private readonly IDataContext _context;

    public UpdateCommandHandlerOfCrewMember(IDataContext context)
        => (_context) = (context);

    public async Task<Guid> Handle(UpdateCommandOfCrewMember request, CancellationToken token)
    {
        var member = await _context.CrewMembers
            .FirstOrDefaultAsync(member => member.CrewMemberId == request.CrewMemberId);

        if (member == null)
            throw new NotFoundException(nameof(member), request.CrewMemberId);

        member.CrewId = request.CrewId;
        member.Salary = request.Salary;
        member.PhoneNumber = request.PhoneNumber;
        member.FullName = request.FullName;
        member.JobTitle = request.JobTitle;

        await _context.SaveChangesAsync(token);
        return member.CrewMemberId;
    }
}