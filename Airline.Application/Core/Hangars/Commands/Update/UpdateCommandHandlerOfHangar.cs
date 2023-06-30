using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Hangars.Commands.Update;

public class UpdateCommandHandlerOfHangar : IRequestHandler<UpdateCommandOfHangar, Guid>
{
    private readonly IDataContext _context;
    private readonly IMapper _mapper;

    public UpdateCommandHandlerOfHangar(IDataContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<Guid> Handle(UpdateCommandOfHangar request, CancellationToken token)
    {
        var hangar = await _context.Hangars
            .FirstOrDefaultAsync(hangar => hangar.HangarId == request.HangarId);

        if (hangar == null)
            throw new NotFoundException(nameof(hangar), request.HangarId);

        hangar.IsUsed = request.IsUsed;
        hangar.AirplaneId = request.AirplaneId;
        hangar.CurrentAirdromeId = request.CurrentAirdromeId;

        await _context.SaveChangesAsync(token);
        return hangar.HangarId;
    }
}