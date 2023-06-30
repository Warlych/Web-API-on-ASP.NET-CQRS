using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Hangars.Commands.Update;

public class UpdateCommandValidatorOfHangar : AbstractValidator<UpdateCommandOfHangar>
{
    private readonly IDataContext _context;
    
    public UpdateCommandValidatorOfHangar(IDataContext context)
    {
        _context = context;
        
        RuleFor(hangar => hangar.HangarId).NotEqual(Guid.Empty).NotEmpty();
        RuleFor(hangar => hangar).Must((hangar) =>
        {
            return IsAirdromeAndAirplaneSatisfyCondition(hangar);
        });
    }

    private bool IsAirdromeAndAirplaneSatisfyCondition(UpdateCommandOfHangar request)
    {
        if (request.IsUsed == true && request.AirplaneId == Guid.Empty)
            throw new EditException(@"to indicate that the hangar is in use, you must specify ""AirplaneId""");
        
        var airplane = _context.Airplanes
            .FirstOrDefault(airplane => airplane.AirplaneId == request.AirplaneId);

        if (airplane == null)
            throw new NotFoundException(nameof(airplane), request.AirplaneId);

        var airdrome = _context.Airdromes
            .FirstOrDefault(airdrome => airdrome.AirdromeId == request.CurrentAirdromeId);

        if (airdrome == null)
            throw new NotFoundException(nameof(airdrome), request.CurrentAirdromeId);

        return true;
    }
}