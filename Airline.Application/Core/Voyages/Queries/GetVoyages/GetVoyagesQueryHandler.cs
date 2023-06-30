using Airline.Application.Core.Voyages.Queries.Model;
using Airline.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Voyages.Queries.GetVoyages;

public class GetVoyagesQueryHandler : IRequestHandler<GetVoyagesQuery, VoyageDetail[]>
{
    private readonly IDataContext _context;
    private readonly IMapper _mapper;

    public GetVoyagesQueryHandler(IDataContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);
    
    public async Task<VoyageDetail[]> Handle(GetVoyagesQuery query, CancellationToken token)
    {
        var entities = new List<VoyageDetail>();
        
        await _context.Voyages.ForEachAsync(voyage =>
        {
            entities.Add(_mapper.Map<VoyageDetail>(voyage));
        }, token);

        return entities.ToArray();
    }
}