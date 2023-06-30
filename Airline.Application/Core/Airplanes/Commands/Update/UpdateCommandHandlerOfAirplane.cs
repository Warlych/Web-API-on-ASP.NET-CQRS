using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using Airline.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Airplanes.Commands.Update;

public class UpdateCommandHandlerOfAirplane : IRequestHandler<UpdateCommandOfAirplane, Guid>
{
    private readonly IDataContext _context;

    public UpdateCommandHandlerOfAirplane(IDataContext context)
        => (_context) = (context);

    public async Task<Guid> Handle(UpdateCommandOfAirplane request, CancellationToken token)
    {
        var airplane = await _context.Airplanes
            .FirstOrDefaultAsync(airplane =>
            airplane.AirplaneId == request.AirplaneId, token);

        if (airplane == null)
            throw new NotFoundException(nameof(airplane), request.AirplaneId);
        
        airplane.Name = request.Name;
        airplane.ModelId = request.ModelId;
        airplane.CurrentCrewId = request.CurrentCrewId;
        
        await _context.SaveChangesAsync(token);
        return airplane.AirplaneId;
    }
}