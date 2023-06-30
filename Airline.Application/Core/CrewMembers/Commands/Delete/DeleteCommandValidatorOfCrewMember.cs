using FluentValidation;

namespace Airline.Application.Core.CrewMembers.Commands.Delete;

public class DeleteCommandValidatorOfCrewMember : AbstractValidator<DeleteCommandOfCrewMember>
{
    public DeleteCommandValidatorOfCrewMember()
    {
        RuleFor(member => member.CrewMemberId).NotEqual(Guid.Empty).NotEmpty();
    }
}