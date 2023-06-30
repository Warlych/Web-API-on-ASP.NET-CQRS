using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using Airline.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Airdromes.Commands.Update;

public class UpdateCommandHandlerOfAirdrome : IRequestHandler<UpdateCommandOfAirdrome, Guid>
{
    private readonly IDataContext _context;

    public UpdateCommandHandlerOfAirdrome(IDataContext context)
        => (_context) = (context);

    public async Task<Guid> Handle(UpdateCommandOfAirdrome request, CancellationToken token)
    {
        var airdrome = await _context.Airdromes
            .Include(airdrome => airdrome.Models)
            .FirstOrDefaultAsync(airdrome => airdrome.AirdromeId == request.AirdromeId, token);

        if (airdrome == null)
            throw new NotFoundException(nameof(airdrome), request.AirdromeId);

        var models = new List<AirplaneModel>();
        foreach (var modelId in request.Models)
        {
            var model = await _context.AirplaneModels
                .FirstOrDefaultAsync(model => model.ModelId == modelId, token);

            if (model == null)
                throw new NotFoundException(nameof(model), modelId);
            
            if(!airdrome.Models.Equals(model)) 
                models.Add(model);
        }

        airdrome.Name = request.Name;
        airdrome.Models = models;
        airdrome.DowntimeCostPerHour = request.DowntimeCostPerHour;

        await _context.SaveChangesAsync(token);
        return airdrome.AirdromeId;
    }
}