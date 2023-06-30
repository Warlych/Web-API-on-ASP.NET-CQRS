using FluentValidation;

namespace Airline.Application.Core.Airdromes.Queries.GetAirdrome;

public class GetAirdromeQueryValidator : AbstractValidator<GetAirdromeQuery>
{
    public GetAirdromeQueryValidator()
    {
        RuleFor(airdrome => airdrome.AirdromeId).NotEqual(Guid.Empty).NotEmpty();
    }
}