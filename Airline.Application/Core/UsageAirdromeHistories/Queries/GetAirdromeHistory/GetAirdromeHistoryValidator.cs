using FluentValidation;

namespace Airline.Application.Core.UsageAirdromeHistories.Queries.GetAirdromeHistories;

public class GetAirdromeHistoryValidator : AbstractValidator<GetAirdromeHistoryQuery>
{
    public GetAirdromeHistoryValidator()
    {
        RuleFor(history => history.AirdromeId).NotEqual(Guid.Empty).NotEmpty();
    }
}