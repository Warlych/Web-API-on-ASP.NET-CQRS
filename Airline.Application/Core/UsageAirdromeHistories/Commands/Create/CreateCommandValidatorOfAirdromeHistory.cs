using FluentValidation;

namespace Airline.Application.Core.UsageAirdromeHistories.Commands.Create;

public class CreateCommandValidatorOfAirdromeHistory : AbstractValidator<CreateCommandOfAirdromeHistory>
{
    public CreateCommandValidatorOfAirdromeHistory()
    {
        RuleFor(history => history.AirdromeId).NotEqual(Guid.Empty).NotEmpty();
        RuleFor(history => history.AirplaneId).NotEqual(Guid.Empty).NotEmpty();
        RuleFor(history => history.StartOfUse).NotEmpty();
        RuleFor(history => history.EndOfUse).NotEmpty();
    }
}