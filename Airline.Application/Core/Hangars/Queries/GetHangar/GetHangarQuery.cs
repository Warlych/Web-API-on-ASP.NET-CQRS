using Airline.Application.Core.Hangars.Queries.Model;
using MediatR;

namespace Airline.Application.Core.Hangars.Queries.GetHangar;

public class GetHangarQuery : IRequest<HangarDetail>
{
    public required Guid HangarId { get; set; }
}