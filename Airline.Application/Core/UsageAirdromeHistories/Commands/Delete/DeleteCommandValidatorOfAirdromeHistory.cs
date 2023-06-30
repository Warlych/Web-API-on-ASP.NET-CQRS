using FluentValidation;

namespace Airline.Application.Core.UsageAirdromeHistories.Commands.Delete;

public class DeleteCommandValidatorOfAirdromeHistory : AbstractValidator<DeleteCommandOfAirdromeHistory>
{
    public DeleteCommandValidatorOfAirdromeHistory()
    {
        RuleFor(history => history.AirdromeId).NotEqual(Guid.Empty).NotEmpty();
        RuleFor(history => history.AirplaneId).NotEqual(Guid.Empty).NotEmpty();
    }
}