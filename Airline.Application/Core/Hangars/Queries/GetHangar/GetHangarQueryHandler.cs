using Airline.Application.Common.Expections;
using Airline.Application.Core.Hangars.Queries.Model;
using Airline.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Hangars.Queries.GetHangar;

public class GetHangarQueryHandler : IRequestHandler<GetHangarQuery, HangarDetail>
{
    private readonly IDataContext _context;
    private readonly IMapper _mapper;

    public GetHangarQueryHandler(IDataContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<HangarDetail> Handle(GetHangarQuery query, CancellationToken token)
    {
        var hangar = await _context.Hangars
            .FirstOrDefaultAsync(hangar => hangar.HangarId == query.HangarId, token);

        if (hangar == null)
            throw new NotFoundException(nameof(hangar), query.HangarId);

        return _mapper.Map<HangarDetail>(hangar);
    }
}