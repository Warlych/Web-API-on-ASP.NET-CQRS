using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using Airline.Domain;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Voyages.Commands.Create;

public class CreateCommandHandlerOfVoyage : IRequestHandler<CreateCommandOfVoyage, Guid>
{
    private readonly IDataContext _context;
    private readonly IMapper _mapper;

    public CreateCommandHandlerOfVoyage(IDataContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<Guid> Handle(CreateCommandOfVoyage request, CancellationToken token)
    {
        var voyage = _mapper.Map<Voyage>(request);
        voyage.VoyageId = Guid.NewGuid();

        await _context.Airdromes
            .Include(airdrome => airdrome.Hangars)
            .ForEachAsync(airdrome =>
            {
                if (airdrome.AirdromeId == voyage.StartId || airdrome.AirdromeId == voyage.EndId)
                {
                    var can = false;
                    foreach (var hangar in airdrome.Hangars)
                    {
                        if (hangar.IsUsed == false)
                        {
                            can = true;
                            break;
                        }
                        else
                            throw new CannotBeUsedException(nameof(airdrome.Name), airdrome.AirdromeId);
                    }
                }
            });

        await _context.Voyages.AddAsync(voyage, token);
        await _context.SaveChangesAsync(token);

        return voyage.VoyageId;
    }
}