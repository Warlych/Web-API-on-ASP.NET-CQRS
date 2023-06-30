using MediatR;

namespace Airline.Application.Core.Hangars.Commands.Delete;

public class DeleteCommandOfHangar : IRequest
{
    public required Guid HangarId { get; set; }
}