using Airline.Application.Common.Expections;
using Airline.Application.Core.Airplanes.Queries.Model;
using Airline.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Airplanes.Queries.GetAirplane;

public class GetAirplaneQueryHandler : IRequestHandler<GetAirplaneQuery, AirplaneDetail>
{
    private readonly IDataContext _context;
    private readonly IMapper _mapper;

    public GetAirplaneQueryHandler(IDataContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<AirplaneDetail> Handle(GetAirplaneQuery query, CancellationToken token)
    {
        var entity = await _context.Airplanes.FirstOrDefaultAsync(airplane =>
            airplane.AirplaneId == query.AirplaneId, token);

        if (entity == null)
            throw new NotFoundException(nameof(entity), query.AirplaneId);

        return _mapper.Map<AirplaneDetail>(entity);
    }
}