using Airline.Domain;
using MediatR;

namespace Airline.Application.Core.AirplaneModels.Commands.Update;

public class UpdateCommandOfAirplaneModel : IRequest<Guid>
{
    public required Guid ModelId { get; set; }
    public required string ModelName { get; set; }
    public required int CrewCount { get; set; }
    public required int TotalSeats { get; set; }
    public required int RunwayLength { get; set; }
    public required int FuelTankSize { get; set; }
    public required int FuelConsumptionPerHour { get; set; }
}