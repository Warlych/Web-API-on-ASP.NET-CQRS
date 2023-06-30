using MediatR;

namespace Airline.Application.Core.Airdromes.Commands.Delete;

public class DeleteCommandOfAirdrome : IRequest
{
    public required Guid AirdromeId { get; set; }
}