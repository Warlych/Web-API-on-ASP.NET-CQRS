using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Airplanes.Commands.Create;

public class CreateCommandValidatorOfAirplane : AbstractValidator<CreateCommandOfAirplane>
{
    private readonly IDataContext _context;
    
    public CreateCommandValidatorOfAirplane(IDataContext context)
    {
        _context = context;

        RuleFor(airplane => airplane.Name).NotEmpty();
        RuleFor(airplane => airplane).Must((airplane) =>
        {
            var can =  IsModelExists(airplane);
            return can;
        });
    }
    
    private bool IsModelExists(CreateCommandOfAirplane request)
    {
        var model = _context.AirplaneModels
            .FirstOrDefault(model => model.ModelId == request.ModelId);

        if (model == null)
            throw new NotFoundException(nameof(model), request.ModelId);

        return true;
    }
}