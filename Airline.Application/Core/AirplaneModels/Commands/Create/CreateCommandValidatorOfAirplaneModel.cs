using FluentValidation;

namespace Airline.Application.Core.AirplaneModels.Commands.Create;

public class CreateCommandValidatorOfAirplaneModel : AbstractValidator<CreateCommandOfAirplaneModel>
{
    public CreateCommandValidatorOfAirplaneModel()
    {
        RuleFor(model => model.ModelName).NotEmpty();
        RuleFor(model => model.CrewCount).NotEmpty();
        RuleFor(model => model.TotalSeats).NotEmpty();
        RuleFor(model => model.RunwayLength).NotEmpty();
        RuleFor(model => model.FuelTankSize).NotEmpty();
        RuleFor(model => model.FuelConsumptionPerHour).NotEmpty();
    }
}