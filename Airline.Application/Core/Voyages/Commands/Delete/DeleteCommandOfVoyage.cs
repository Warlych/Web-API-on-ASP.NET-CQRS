using MediatR;

namespace Airline.Application.Core.Voyages.Commands.Delete;

public class DeleteCommandOfVoyage : IRequest
{
    public Guid VoyageId { get; set; }
}