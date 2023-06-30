using FluentValidation;

namespace Airline.Application.Core.AirplaneModels.Queries.GetModel;

public class GetAirplaneModelQueryValidator : AbstractValidator<GetAirplaneModelQuery>
{
    public GetAirplaneModelQueryValidator()
    {
        RuleFor(model => model.ModelId).NotEqual(Guid.Empty).NotEmpty();
    }
}