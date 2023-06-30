using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Voyages.Commands.Update;

public class UpdateCommandValidatorOfVoyage : AbstractValidator<UpdateCommandOfVoyage>
{
    private readonly IDataContext _context;

    public UpdateCommandValidatorOfVoyage(IDataContext context)
    {
        _context = context;

        RuleFor(voyage => voyage.VoyageId).NotEqual(Guid.Empty).NotEmpty();
        RuleFor(voyage => voyage.Name).NotEmpty();
        RuleFor(voyage => voyage.From).NotEmpty();
        RuleFor(voyage => voyage.To).NotEmpty();
        RuleFor(voyage => voyage.FlightLength).NotEmpty();
        RuleFor(voyage => voyage.FlightDate).NotEmpty();
        RuleFor(voyage => voyage.FlightTime).NotEmpty();
        RuleFor(voyage => voyage.TicketPrice).NotEmpty();
        RuleFor(voyage => voyage.StartId).NotEqual(Guid.Empty).NotEmpty();
        RuleFor(voyage => voyage.EndId).NotEqual(Guid.Empty).NotEmpty();
        RuleFor(voyage => voyage).Must((voyage) =>
        {
            return IsAirplaneAndAirdromeSatisfyCondition(voyage);
        });
    }

    private bool IsAirplaneAndAirdromeSatisfyCondition(UpdateCommandOfVoyage request)
    {
        var airdromes = _context.Airdromes
            .Include(airdrome => airdrome.Hangars)
            .Where(airdrome => airdrome.AirdromeId == request.StartId || airdrome.AirdromeId == request.EndId).ToList();

        foreach (var airdrome in airdromes)
        {
            var can = false;
            foreach (var hangar in airdrome.Hangars)
            {
                if (hangar.IsUsed == false)
                {
                    can = true;
                    break;
                }
                else
                    throw new CannotBeUsedException(nameof(airdrome.Name), airdrome.AirdromeId);
            }
        }

        var airplane = _context.Airplanes
            .Include(airplane => airplane.Voyages)
            .FirstOrDefault(airplane => airplane.AirplaneId == request.CurrentAirplaneId);

        if (airplane == null)
            throw new NotFoundException(nameof(airplane), request.CurrentAirplaneId);

        foreach (var airplaneVoyage in airplane.Voyages)
            if (airplaneVoyage.FlightDate == request.FlightDate)
                throw new CannotBeUsedException(nameof(airplane), request.CurrentAirplaneId);

        return true;
    }
}