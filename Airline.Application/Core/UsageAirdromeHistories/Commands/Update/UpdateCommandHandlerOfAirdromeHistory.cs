using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using Airline.Domain;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.UsageAirdromeHistories.Commands.Update;

public class UpdateCommandHandlerOfAirdromeHistory : IRequestHandler<UpdateCommandOfAirdromeHistory, Guid>
{
    private readonly IDataContext _context;
    private readonly IMapper _mapper;

    public UpdateCommandHandlerOfAirdromeHistory(IDataContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<Guid> Handle(UpdateCommandOfAirdromeHistory request, CancellationToken token)
    {
        var history = await _context.AirdromeHistories
            .FirstOrDefaultAsync(history => history.AirplaneId == request.AirplaneId, token);

        if (history == null)
            throw new NotFoundException(nameof(history), request.AirplaneId);
        
        var airplane = await _context.Airplanes
            .FirstOrDefaultAsync(airplane => airplane.AirplaneId == request.AirplaneId, token);

        if (airplane == null)
            throw new NotFoundException(nameof(airplane), request.AirplaneId);

        var airdrome = await _context.Airdromes
            .FirstOrDefaultAsync(airdrome => airdrome.AirdromeId == request.AirdromeId, token);

        if (airdrome == null)
            throw new NotFoundException(nameof(airdrome), request.AirdromeId);

        history.AirdromeId = request.AirdromeId;
        history.StartOfUse = request.StartOfUse;
        history.EndOfUse = request.EndOfUse;
        
        await _context.SaveChangesAsync(token);
        return airdrome.AirdromeId;
    }
}