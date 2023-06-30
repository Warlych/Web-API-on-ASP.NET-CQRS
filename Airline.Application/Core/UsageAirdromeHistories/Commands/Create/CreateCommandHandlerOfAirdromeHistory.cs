using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using Airline.Domain;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.UsageAirdromeHistories.Commands.Create;

public class CreateCommandHandlerOfAirdromeHistory : IRequestHandler<CreateCommandOfAirdromeHistory, Guid>
{
    private readonly IDataContext _context;
    private readonly IMapper _mapper;

    public CreateCommandHandlerOfAirdromeHistory(IDataContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<Guid> Handle(CreateCommandOfAirdromeHistory request, CancellationToken token)
    {
        var airplane = await _context.Airplanes
            .FirstOrDefaultAsync(airplane => airplane.AirplaneId == request.AirplaneId, token);

        if (airplane == null)
            throw new NotFoundException(nameof(airplane), request.AirplaneId);

        var airdrome = await _context.Airdromes
            .FirstOrDefaultAsync(airdrome => airdrome.AirdromeId == request.AirdromeId, token);

        if (airdrome == null)
            throw new NotFoundException(nameof(airdrome), request.AirdromeId);

        var entity = _mapper.Map<UsageAirdromeHistory>(request);
        await _context.AirdromeHistories.AddAsync(entity, token);
        await _context.SaveChangesAsync(token);

        return airdrome.AirdromeId;
    }
}