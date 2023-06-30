using Airline.Application.Common.Expections;
using Airline.Application.Core.Airdromes.Queries.Model;
using Airline.Application.Core.AirplaneModels.Queries.Model;
using Airline.Application.Core.Hangars.Queries.Model;
using Airline.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Airdromes.Queries.GetAirdrome;

public class GetAirdromeQueryHandler : IRequestHandler<GetAirdromeQuery, AirdromeDetail>
{
    private readonly IDataContext _context;
    private readonly IMapper _mapper;

    public GetAirdromeQueryHandler(IDataContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<AirdromeDetail> Handle(GetAirdromeQuery query, CancellationToken token)
    {
        var airdrome = await _context.Airdromes
            .FirstOrDefaultAsync(airdrome => airdrome.AirdromeId == query.AirdromeId, token);

        if (airdrome == null)
            throw new NotFoundException(nameof(airdrome), query.AirdromeId);

        var hangars = new List<HangarDetail>();
        foreach(var hangar in airdrome.Hangars)
            hangars.Add(_mapper.Map<HangarDetail>(hangar));

        var models = new List<AirplaneModelDetail>();
        foreach(var model in airdrome.Models)
            models.Add(_mapper.Map<AirplaneModelDetail>(model));
        
        var airdromeDetail = _mapper.Map<AirdromeDetail>(airdrome);
        airdromeDetail.Hangars = hangars;
        airdromeDetail.Models = models;

        return airdromeDetail;
    }
}