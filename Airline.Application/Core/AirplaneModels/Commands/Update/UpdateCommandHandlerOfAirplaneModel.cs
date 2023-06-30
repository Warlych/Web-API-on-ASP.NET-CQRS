using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.AirplaneModels.Commands.Update;

public class UpdateCommandHandlerOfAirplaneModel : IRequestHandler<UpdateCommandOfAirplaneModel, Guid>
{
    private readonly IDataContext _context;

    public UpdateCommandHandlerOfAirplaneModel(IDataContext context) =>
        _context = context;
    
    public async Task<Guid> Handle(UpdateCommandOfAirplaneModel request, CancellationToken token)
    {
        var airplaneModel = await _context.AirplaneModels.FirstOrDefaultAsync(model => 
                model.ModelId == request.ModelId, token);

        if (airplaneModel == null) 
            throw new NotFoundException(nameof(airplaneModel), request.ModelId);
        
        airplaneModel.ModelName = request.ModelName;
        airplaneModel.CrewCount = request.CrewCount;
        airplaneModel.TotalSeats = request.TotalSeats;
        airplaneModel.RunwayLength = request.RunwayLength;
        airplaneModel.FuelTankSize = request.FuelTankSize;
        airplaneModel.FuelConsumptionPerHour = request.FuelConsumptionPerHour;

        await _context.SaveChangesAsync(token);

        return airplaneModel.ModelId;
    }
}