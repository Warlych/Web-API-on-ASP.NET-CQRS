using FluentValidation;

namespace Airline.Application.Core.CrewMembers.Commands.Create;

public class CreateCommandValidatorOfCrewMember : AbstractValidator<CreateCommandOfCrewMember>
{
    public CreateCommandValidatorOfCrewMember()
    {
        RuleFor(member => member.FullName).NotEmpty();
        RuleFor(member => member.PhoneNumber).NotEmpty();
        RuleFor(member => member.Salary).NotEmpty();
        RuleFor(member => member.JobTitle).NotEmpty();
    }
}