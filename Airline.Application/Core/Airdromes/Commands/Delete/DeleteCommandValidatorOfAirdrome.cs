using FluentValidation;

namespace Airline.Application.Core.Airdromes.Commands.Delete;

public class DeleteCommandValidatorOfAirdrome : AbstractValidator<DeleteCommandOfAirdrome>
{
    public DeleteCommandValidatorOfAirdrome()
    {
        RuleFor(airdrome => airdrome.AirdromeId).NotEqual(Guid.Empty).NotEmpty();
    }
}