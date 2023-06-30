using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Airplanes.Queries.FlightOfTheAirplane;

public class GetQuantityFlyingKilometresQueryHandler : IRequestHandler<GetQuantityFlyingKilometresQuery, Dictionary<string, double>>
{
    private readonly IDataContext _context;

    public GetQuantityFlyingKilometresQueryHandler(IDataContext context)
        => (_context) = (context);

    public async Task<Dictionary<string, double>> Handle(GetQuantityFlyingKilometresQuery query,
        CancellationToken token)
    {
        if (query.AirplaneId.Equals(Guid.Empty))
        {
            Dictionary<string, double> airplaneToQuantity = new Dictionary<string, double>();

            await _context.Airplanes
                .Include(a => a.Voyages)
                .ForEachAsync(a =>
                {
                    var result = 0.0;
                    foreach (var voyage in a.Voyages)
                    {
                        result += voyage.FlightLength;
                    }

                    airplaneToQuantity.Add(a.Name, result);
                }, token);

            return airplaneToQuantity;
        }
        else
        {
            var entity = await _context.Airplanes
                .Include(a => a.Voyages)
                .FirstOrDefaultAsync(a => a.AirplaneId.Equals(query.AirplaneId), token);

            if (entity == null)
                throw new NotFoundException(nameof(entity), query.AirplaneId);

            var result = 0.0;
            foreach (var voyage in entity.Voyages)
            {
                result += voyage.FlightLength;
            }

            return new Dictionary<string, double>() { { entity.Name, result } };
        }
    }
}