using Airline.Application.Interfaces;
using FluentValidation;

namespace Airline.Application.Core.Airdromes.Commands.Update;

public class UpdateCommandValidatorOfAirdrome : AbstractValidator<UpdateCommandOfAirdrome>
{
    public UpdateCommandValidatorOfAirdrome()
    {
        RuleFor(airdrome => airdrome.AirdromeId).NotEqual(Guid.Empty).NotEmpty();
        RuleFor(airdrome => airdrome.Name).NotEmpty();
        RuleFor(airdrome => airdrome.DowntimeCostPerHour).NotEmpty();
        RuleFor(airdrome => airdrome.Models).NotEmpty();
    }
}