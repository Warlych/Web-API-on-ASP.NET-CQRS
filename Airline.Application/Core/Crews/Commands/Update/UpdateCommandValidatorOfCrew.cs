using FluentValidation;

namespace Airline.Application.Core.Crews.Commands.Update;

public class UpdateCommandValidatorOfCrew : AbstractValidator<UpdateCommandOfCrew>
{
    public UpdateCommandValidatorOfCrew()
    {
        RuleFor(crew => crew.CrewId).NotEqual(Guid.Empty).NotEmpty();
        RuleFor(crew => crew.Name).NotEmpty();
        RuleFor(crew => crew.Members).NotEmpty();
    }
}