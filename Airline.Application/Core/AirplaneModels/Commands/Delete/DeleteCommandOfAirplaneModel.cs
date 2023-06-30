using MediatR;

namespace Airline.Application.Core.AirplaneModels.Commands.Delete;

public class DeleteCommandOfAirplaneModel : IRequest
{
    public Guid ModelId { get; set; }
}