using FluentValidation;

namespace Airline.Application.Core.Hangars.Commands.Delete;

public class DeleteCommandValidatorOfHangar : AbstractValidator<DeleteCommandOfHangar>
{
    public DeleteCommandValidatorOfHangar()
    {
        RuleFor(hangar => hangar.HangarId).NotEqual(Guid.Empty).NotEmpty();
    }
}