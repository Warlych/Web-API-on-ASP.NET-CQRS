using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Voyages.Queries.Occupancy;

public class GetVoyageOccupancyQueryHandler : IRequestHandler<GetVoyageOccupancyQuery, double>
{
    private readonly IDataContext _context;

    public GetVoyageOccupancyQueryHandler(IDataContext context)
        => (_context) = (context);
    
    public async Task<double> Handle(GetVoyageOccupancyQuery query, CancellationToken token)
    {
        var entity = await _context.Voyages
            .Include(v=>v.CurrentAirplane)
            .FirstOrDefaultAsync(v => v.VoyageId == query.VoyageId, token);

        if (entity == null)
            throw new NotFoundException(nameof(entity), query.VoyageId);
        
        var totalSeats = (await _context.AirplaneModels
            .FirstOrDefaultAsync(m => m.ModelId == entity.CurrentAirplane.ModelId, token)).TotalSeats;

        double? result = (double)entity.SoldSeats / totalSeats;

        return result ?? 0;
    }
}