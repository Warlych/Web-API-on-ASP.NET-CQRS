using FluentValidation;

namespace Airline.Application.Core.AirplaneModels.Commands.Delete;

public class DeleteCommandValidatorOfAirplaneModel : AbstractValidator<DeleteCommandOfAirplaneModel>
{
    public DeleteCommandValidatorOfAirplaneModel()
    {
        RuleFor(model => model.ModelId).NotEqual(Guid.Empty).NotEmpty();
    }
}