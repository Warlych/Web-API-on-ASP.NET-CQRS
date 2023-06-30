using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using Airline.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Voyages.Commands.Update;

public class UpdateCommandHandlerOfVoyage : IRequestHandler<UpdateCommandOfVoyage, Guid>
{
    private readonly IDataContext _context;
    public UpdateCommandHandlerOfVoyage(IDataContext context)
        => (_context) = (context);

    public async Task<Guid> Handle(UpdateCommandOfVoyage request, CancellationToken token)
    {
        var voyage = await _context.Voyages.FirstOrDefaultAsync(voyage =>
            voyage.VoyageId == request.VoyageId, token);

        if (voyage == null)
            throw new NotFoundException(nameof(voyage), request.VoyageId);

        voyage.Name = request.Name;
        voyage.To = request.To;
        voyage.From = request.From;
        voyage.FlightDate = request.FlightDate;
        voyage.FlightLength = request.FlightLength;
        voyage.TicketPrice = request.TicketPrice;
        voyage.FlightTime = request.FlightTime;
        voyage.StartId = request.StartId;
        voyage.EndId = request.EndId;
        voyage.CurrentAirplaneId = request.CurrentAirplaneId;
        voyage.SoldSeats = request.SoldSeats;
        voyage.LeftSeats = request.LeftSeats;

        await _context.SaveChangesAsync(token);

        return voyage.VoyageId;
    }
}