using Airline.Application.Core.AirplaneModels.Commands.Create;
using FluentValidation;

namespace Airline.Application.Core.AirplaneModels.Commands.Update;

public class UpdateCommandValidatorOfAirplaneModel : AbstractValidator<UpdateCommandOfAirplaneModel>
{
    public UpdateCommandValidatorOfAirplaneModel()
    {
        RuleFor(model => model.ModelId).NotEqual(Guid.Empty).NotEmpty();
        RuleFor(model => model.ModelName).NotEmpty();
        RuleFor(model => model.CrewCount).NotEmpty();
        RuleFor(model => model.TotalSeats).NotEmpty();
        RuleFor(model => model.RunwayLength).NotEmpty();
        RuleFor(model => model.FuelTankSize).NotEmpty();
        RuleFor(model => model.FuelConsumptionPerHour).NotEmpty();
    }
}