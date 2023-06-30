using FluentValidation;

namespace Airline.Application.Core.Hangars.Queries.GetHangar;

public class GetHangarQueryValidator : AbstractValidator<GetHangarQuery>
{
    public GetHangarQueryValidator()
    {
        RuleFor(hangar => hangar.HangarId).NotEqual(Guid.Empty).NotEmpty();
    }
}