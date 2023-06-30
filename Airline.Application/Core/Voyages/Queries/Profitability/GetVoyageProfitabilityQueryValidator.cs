using FluentValidation;

namespace Airline.Application.Core.Voyages.Queries.Profitability;

public class GetVoyageProfitabilityQueryValidator : AbstractValidator<GetVoyageProfitabilityQuery>
{
    public GetVoyageProfitabilityQueryValidator()
    {
        RuleFor(voyage => voyage.VoyageId).NotEqual(Guid.Empty).NotEmpty();
    }
}