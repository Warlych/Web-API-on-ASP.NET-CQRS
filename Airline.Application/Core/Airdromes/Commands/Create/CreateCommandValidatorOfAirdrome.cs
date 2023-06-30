using FluentValidation;

namespace Airline.Application.Core.Airdromes.Commands.Create;

public class CreateCommandValidatorOfAirdrome : AbstractValidator<CreateCommandOfAirdrome>
{
    public CreateCommandValidatorOfAirdrome()
    {
        RuleFor(airdrome => airdrome.Name).NotEmpty();
        RuleFor(airdrome => airdrome.DowntimeCostPerHour).NotEmpty();
    }
}