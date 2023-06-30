using Airline.Application.Interfaces;
using Airline.Domain;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Crews.Commands.Delete;

public class DeleteCommandValidatorOfCrew : AbstractValidator<DeleteCommandOfCrew>
{
    private readonly IDataContext _context;
    
    public DeleteCommandValidatorOfCrew(IDataContext context)
    {
        _context = context;
        
        RuleFor(crew => crew.CrewId).NotEqual(Guid.Empty).NotEmpty();
        RuleFor(crew => crew).Must(crew =>
        {
            return IsDoesntFly(crew);
        });
    }

    private bool IsDoesntFly(DeleteCommandOfCrew request)
    {
        var airplane = _context.Airplanes
            .Include(airplane => airplane.Voyages)
            .Include(airplane => airplane.CurrentCrew)
            .FirstOrDefault(airplane => airplane.CurrentCrew.CrewId == request.CrewId);

        if (airplane == null)
            return true;

        foreach (var voyage in airplane.Voyages)
        {
            if (voyage.FlightDate == DateTime.Now)
                return false;
        }

        return true;
    }
}