using Airline.Application.Core.Airdromes.Queries.Model;
using Airline.Application.Core.AirplaneModels.Queries.Model;
using Airline.Application.Core.Hangars.Queries.Model;
using Airline.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Airdromes.Queries.GetAirdromes;

public class GetAirdromesQueryHandler : IRequestHandler<GetAirdromesQuery, AirdromeDetail[]>
{
    private readonly IDataContext _context;
    private readonly IMapper _mapper;

    public GetAirdromesQueryHandler(IDataContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<AirdromeDetail[]> Handle(GetAirdromesQuery query, CancellationToken token)
    {
        var airdromes = new List<AirdromeDetail>();
        
        await _context.Airdromes
            .Include(airdrome => airdrome.Hangars)
            .Include(airdrome => airdrome.Models)
            .ForEachAsync(airdrome =>
            {
                var hangars = new List<HangarDetail>();
                foreach(var hangar in airdrome.Hangars)
                    hangars.Add(_mapper.Map<HangarDetail>(hangar));

                var models = new List<AirplaneModelDetail>();
                    foreach(var model in airdrome.Models)
                        models.Add(_mapper.Map<AirplaneModelDetail>(model));

                var airdromeDetail = _mapper.Map<AirdromeDetail>(airdrome);
                airdromeDetail.Hangars = hangars;
                airdromeDetail.Models = models;

                airdromes.Add(airdromeDetail);
            }, token);

        return airdromes.ToArray();
    }
}