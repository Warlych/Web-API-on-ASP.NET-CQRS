using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Hangars.Commands.Create;

public class CreateCommandValidatorOfHangar : AbstractValidator<CreateCommandOfHangar>
{
    private readonly IDataContext _context;
    
    public CreateCommandValidatorOfHangar(IDataContext context)
    {
        _context = context;
        
        RuleFor(hangar => hangar).Must((hangar) =>
        {
            return IsAirdromeExists(hangar);
        });
    }
    
    private bool IsAirdromeExists(CreateCommandOfHangar request)
    {
        var airdrome =  _context.Airdromes.FirstOrDefault(airdrome => 
            airdrome.AirdromeId == request.CurrentAirdromeId);

        if (airdrome == null)
            throw new NotFoundException(nameof(airdrome), request.CurrentAirdromeId);

        return true;
    }
}