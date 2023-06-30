using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using Airline.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Crews.Commands.Update;

public class UpdateCommandHandlerOfCrew : IRequestHandler<UpdateCommandOfCrew, Guid>
{
    private readonly IDataContext _context;

    public UpdateCommandHandlerOfCrew(IDataContext context)
        => (_context) = (context);

    public async Task<Guid> Handle(UpdateCommandOfCrew request, CancellationToken token)
    {
        var crew = await _context.Crews.FirstOrDefaultAsync(crew => crew.CrewId == request.CrewId, token);

        if (crew == null)
            throw new NotFoundException(nameof(crew), request.CrewId);

        var members = new List<CrewMember>();
        foreach (var memberId in request.Members)
        {
            var member = await _context.CrewMembers
                .Include(member => member.CurrentCrew)
                .FirstOrDefaultAsync(member => member.CrewMemberId == memberId, token);

            if (member == null)
                throw new NotFoundException(nameof(member), memberId);

            var voyage = await _context.Voyages
                .Include(voyage => voyage.CurrentAirplane)
                .Include(voyage => voyage.CurrentAirplane.CurrentCrew)
                .FirstOrDefaultAsync(voyage => voyage.CurrentAirplane.CurrentCrew.CrewId == member.CrewId, token);
            
            if (voyage != null && voyage.FlightDate >= DateTime.Now &&
                DateTime.Now <= voyage.FlightDate + TimeSpan.FromHours(voyage.FlightTime))
                throw new CannotBeUsedException(nameof(member), memberId);
            
            members.Add(member);
        }

        crew.Name = request.Name;
        crew.Members = members;

        await _context.SaveChangesAsync(token);
        return crew.CrewId;
    }
}