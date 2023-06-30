using Airline.Domain;
using MediatR;

namespace Airline.Application.Core.Airdromes.Commands.Update;

public class UpdateCommandOfAirdrome : IRequest<Guid>
{
    public required Guid AirdromeId { get; set; }
    public required string Name { get; set; }
    public List<Guid> Models { get; set; }
    public required double DowntimeCostPerHour { get; set; }
}