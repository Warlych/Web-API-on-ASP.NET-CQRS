using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using MediatR;

namespace Airline.Application.Core.AirplaneModels.Commands.Delete;

public class DeleteCommandHandlerOfAirplaneModel : IRequestHandler<DeleteCommandOfAirplaneModel>
{
    private readonly IDataContext _context;

    public DeleteCommandHandlerOfAirplaneModel(IDataContext context) =>
        _context = context;
    
    public async Task Handle(DeleteCommandOfAirplaneModel request, CancellationToken token)
    {
        var airplaneModel = await _context.AirplaneModels
            .FindAsync(new object[] { request.ModelId }, token);

        if (airplaneModel == null)
            throw new NotFoundException(nameof(airplaneModel), request.ModelId);

        _context.AirplaneModels.Remove(airplaneModel);
        await _context.SaveChangesAsync(token);
    }
}