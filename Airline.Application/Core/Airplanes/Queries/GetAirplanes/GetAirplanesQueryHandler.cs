using Airline.Application.Core.Airplanes.Queries.Model;
using Airline.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Airplanes.Queries.GetAirplanes;

public class GetAirplanesQueryHandler : IRequestHandler<GetAirplanesQuery, AirplaneDetail[]>
{
    private readonly IDataContext _context;
    private readonly IMapper _mapper;

    public GetAirplanesQueryHandler(IDataContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<AirplaneDetail[]> Handle(GetAirplanesQuery query, CancellationToken token)
    {
        var entities = new List<AirplaneDetail>();

        await _context.Airplanes.ForEachAsync(airplane =>
        {
            entities.Add(_mapper.Map<AirplaneDetail>(airplane));
        }, token);

        return entities.ToArray();
    }
}