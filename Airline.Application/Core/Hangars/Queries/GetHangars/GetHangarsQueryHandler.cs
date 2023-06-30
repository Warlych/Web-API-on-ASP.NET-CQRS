using Airline.Application.Core.Hangars.Queries.Model;
using Airline.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Hangars.Queries.GetHangars;

public class GetHangarsQueryHandler : IRequestHandler<GetHangarsQuery, HangarDetail[]>
{
    private readonly IDataContext _context;
    private readonly IMapper _mapper;
    
    public GetHangarsQueryHandler(IDataContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<HangarDetail[]> Handle(GetHangarsQuery query, CancellationToken token)
    {
        var hangars = new List<HangarDetail>();

        await _context.Hangars
            .ForEachAsync(hangar =>
            {
                hangars.Add(_mapper.Map<HangarDetail>(hangar));
            }, token);

        return hangars.ToArray();
    }
}