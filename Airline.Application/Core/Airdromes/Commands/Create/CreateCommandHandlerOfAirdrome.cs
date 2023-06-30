using Airline.Application.Interfaces;
using Airline.Domain;
using AutoMapper;
using MediatR;

namespace Airline.Application.Core.Airdromes.Commands.Create;

public class CreateCommandHandlerOfAirdrome : IRequestHandler<CreateCommandOfAirdrome, Guid>
{
    private readonly IDataContext _context;
    private readonly IMapper _mapper;

    public CreateCommandHandlerOfAirdrome(IDataContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<Guid> Handle(CreateCommandOfAirdrome request, CancellationToken token)
    {
        var airdrome = _mapper.Map<Airdrome>(request);
        airdrome.AirdromeId = Guid.NewGuid();

        await _context.Airdromes.AddAsync(airdrome, token);
        await _context.SaveChangesAsync(token);

        return airdrome.AirdromeId;
    }
}