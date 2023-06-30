using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Airplanes.Commands.Update;

public class UpdateCommandValidatorOfAirplane : AbstractValidator<UpdateCommandOfAirplane>
{
    private readonly IDataContext _context;
    
    public UpdateCommandValidatorOfAirplane(IDataContext context)
    {
        _context = context;
        
        RuleFor(airplane => airplane.AirplaneId).NotEqual(Guid.Empty).NotEmpty();
        RuleFor(airplane => airplane.Name).NotEmpty();
        RuleFor(airplane => airplane).Must((airplane) =>
        {
            return IsModelAndCrewSatisfyCondition(airplane);
        });
    }

    private bool IsModelAndCrewSatisfyCondition(UpdateCommandOfAirplane request)
    {
        var model = _context.AirplaneModels
            .FirstOrDefault(model => model.ModelId == request.ModelId);

        if (model == null)
            throw new NotFoundException(nameof(model), request.ModelId);

        var crew = _context.Crews
            .Include(crew => crew.Members)
            .FirstOrDefault(crew => crew.CrewId == request.CurrentCrewId);

        if (crew == null)
            throw new NotFoundException(nameof(model), request.CurrentCrewId);

        if (model.CrewCount < crew.Members.Count)
            throw new CannotBeUsedException(nameof(crew), crew.CrewId);

        return true;
    }
}