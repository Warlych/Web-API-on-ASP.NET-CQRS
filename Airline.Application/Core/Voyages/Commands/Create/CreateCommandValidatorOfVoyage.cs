using FluentValidation;

namespace Airline.Application.Core.Voyages.Commands.Create;

public class CreateCommandValidatorOfVoyage : AbstractValidator<CreateCommandOfVoyage>
{
    public CreateCommandValidatorOfVoyage()
    {
        RuleFor(voyage => voyage.Name).NotEmpty();
        RuleFor(voyage => voyage.From).NotEmpty();
        RuleFor(voyage => voyage.To).NotEmpty();
        RuleFor(voyage => voyage.FlightLength).NotEmpty();
        RuleFor(voyage => voyage.FlightDate).NotEmpty();
        RuleFor(voyage => voyage.FlightTime).NotEmpty();
        RuleFor(voyage => voyage.TicketPrice).NotEmpty();
        RuleFor(voyage => voyage.StartId).NotEqual(Guid.Empty).NotEmpty();
        RuleFor(voyage => voyage.EndId).NotEqual(Guid.Empty).NotEmpty();
    }
}