using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using MediatR;

namespace Airline.Application.Core.Airplanes.Commands.Delete;

public class DeleteCommandHandlerOfAirplane : IRequestHandler<DeleteCommandOfAirplane>
{
    private readonly IDataContext _context;

    public DeleteCommandHandlerOfAirplane(IDataContext context) =>
        _context = context;
    
    public async Task Handle(DeleteCommandOfAirplane request, CancellationToken token)
    {
        var airplane = await _context.Airplanes
            .FindAsync(new object[] { request.AirplaneId }, token);

        if (airplane == null)
            throw new NotFoundException(nameof(airplane), request.AirplaneId);

        _context.Airplanes.Remove(airplane);
        await _context.SaveChangesAsync(token);
    }
}