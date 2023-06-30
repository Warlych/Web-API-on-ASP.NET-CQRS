using Airline.Application.Core.Crews.Commands.Create;
using FluentValidation;

namespace Airline.Application.Core.CrewMembers.Commands.Create;

public class CreateCommandValidatorOfCrew : AbstractValidator<CreateCommandOfCrew>
{
    public CreateCommandValidatorOfCrew()
    {
        RuleFor(crew => crew.Name).NotEmpty();
    }
}