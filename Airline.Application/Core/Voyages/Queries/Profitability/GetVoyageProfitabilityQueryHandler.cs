using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Voyages.Queries.Profitability;

public class GetVoyageProfitabilityQueryHandler : IRequestHandler<GetVoyageProfitabilityQuery, double>
{
    private readonly IDataContext _context;

    protected static int PriceOneLitreOfFuel = 65;
    
    public GetVoyageProfitabilityQueryHandler(IDataContext context)
        => (_context) = (context);
    
    public async Task<double> Handle(GetVoyageProfitabilityQuery query, CancellationToken token)
    {
        var entity = await _context.Voyages
            .Include(v => v.CurrentAirplane)
            .FirstOrDefaultAsync(v => v.VoyageId == query.VoyageId, token);

        if (entity == null)
            throw new NotFoundException(nameof(entity), query.VoyageId);
        
        var fuelConsumptionPerHour = (await _context.AirplaneModels
                .FirstOrDefaultAsync(m => m.ModelId == entity.CurrentAirplane.ModelId, token))
            .FuelConsumptionPerHour;

        var result = (entity.SoldSeats * entity.TicketPrice - 
                      entity.FlightTime * fuelConsumptionPerHour * PriceOneLitreOfFuel) / (entity.FlightTime * fuelConsumptionPerHour * PriceOneLitreOfFuel);

        return result ?? 0;
    }
}