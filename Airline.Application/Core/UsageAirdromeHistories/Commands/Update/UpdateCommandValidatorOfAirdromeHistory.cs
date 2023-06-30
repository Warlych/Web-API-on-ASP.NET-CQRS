using FluentValidation;

namespace Airline.Application.Core.UsageAirdromeHistories.Commands.Update;

public class UpdateCommandValidatorOfAirdromeHistory : AbstractValidator<UpdateCommandOfAirdromeHistory>
{
    public UpdateCommandValidatorOfAirdromeHistory()
    {
        RuleFor(history => history.AirdromeId).NotEqual(Guid.Empty).NotEmpty();
        RuleFor(history => history.AirplaneId).NotEqual(Guid.Empty).NotEmpty();
        RuleFor(history => history.StartOfUse).NotEmpty();
        RuleFor(history => history.EndOfUse).NotEmpty();
    }
}