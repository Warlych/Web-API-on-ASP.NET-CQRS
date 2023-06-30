using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.UsageAirdromeHistories.Commands.Delete;

public class DeleteCommandHandlerOfAirdromeHistory : IRequestHandler<DeleteCommandOfAirdromeHistory>
{
    private readonly IDataContext _context;
    private readonly IMapper _mapper;

    public DeleteCommandHandlerOfAirdromeHistory(IDataContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task Handle(DeleteCommandOfAirdromeHistory request, CancellationToken token)
    {
        var history = await _context.AirdromeHistories
            .FirstOrDefaultAsync(history => 
                history.AirplaneId == request.AirplaneId && history.AirdromeId == request.AirdromeId, token);

        if (history == null)
            throw new NotFoundException(nameof(history), request.AirdromeId);

        _context.AirdromeHistories.Remove(history);
        await _context.SaveChangesAsync(token);
    }
}