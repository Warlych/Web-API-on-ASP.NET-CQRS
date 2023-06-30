using Airline.Application.Common.Expections;
using Airline.Application.Core.UsageAirdromeHistories.Queries.Model;
using Airline.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.UsageAirdromeHistories.Queries.GetAirdromeHistories;

public class GetAirdromeHistoryQueryHandler : IRequestHandler<GetAirdromeHistoryQuery, AirdromeHistoryDetail[]>
{
    private readonly IDataContext _context;
    private readonly IMapper _mapper;

    public GetAirdromeHistoryQueryHandler(IDataContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<AirdromeHistoryDetail[]> Handle(GetAirdromeHistoryQuery query, CancellationToken token)
    {
        var airdrome = await _context.Airdromes
            .FirstOrDefaultAsync(airdrome => airdrome.AirdromeId == query.AirdromeId, token);

        if (airdrome == null)
            throw new NotFoundException(nameof(airdrome), query.AirdromeId);
        
        var histories = new List<AirdromeHistoryDetail>();

        await _context.AirdromeHistories
            .ForEachAsync(history =>
            {
                if (history.AirdromeId == query.AirdromeId)
                    histories.Add(_mapper.Map<AirdromeHistoryDetail>(history));
            });

        return histories.ToArray();
    }
}