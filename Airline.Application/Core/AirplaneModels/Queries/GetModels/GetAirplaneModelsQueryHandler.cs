using Airline.Application.Core.AirplaneModels.Queries.Model;
using Airline.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.AirplaneModels.Queries.GetModels;

public class GetAirplaneModelsQueryHandler : IRequestHandler<GetAirplaneModelsQuery, AirplaneModelDetail[]>
{
    private readonly IDataContext _context;
    private IMapper _mapper;
    
    public GetAirplaneModelsQueryHandler(IDataContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<AirplaneModelDetail[]> Handle(GetAirplaneModelsQuery query, CancellationToken token)
    {
        var entities = new List<AirplaneModelDetail>();
        
        await _context.AirplaneModels.ForEachAsync(model =>
        {
            entities.Add(_mapper.Map<AirplaneModelDetail>(model));
        });

        return entities.ToArray();
    }
}