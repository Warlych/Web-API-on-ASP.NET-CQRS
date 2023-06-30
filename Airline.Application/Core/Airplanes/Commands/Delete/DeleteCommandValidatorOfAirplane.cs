using Airline.Application.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Airplanes.Commands.Delete;

public class DeleteCommandValidatorOfAirplane : AbstractValidator<DeleteCommandOfAirplane>
{
    private readonly IDataContext _context;
    
    public DeleteCommandValidatorOfAirplane(IDataContext context)
    {
        _context = context;
        
        RuleFor(airplane => airplane.AirplaneId).NotEqual(Guid.Empty).NotEmpty();
        RuleFor(airplane => airplane).Must(airplane =>
        {
            return IsDoesntFly(airplane);
        });
    }

    private bool IsDoesntFly(DeleteCommandOfAirplane request)
    {
        var voyages = _context.Voyages
            .Include(voyage => voyage.CurrentAirplane)
            .Where(voyage => voyage.CurrentAirplane.AirplaneId == request.AirplaneId).ToArray();
        
        foreach (var voyage in voyages)
        {
            if (voyage.FlightDate == DateTime.Now)
                return false;
        }

        return true;
    }
}