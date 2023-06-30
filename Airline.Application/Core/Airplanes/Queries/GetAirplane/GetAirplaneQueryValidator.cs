using FluentValidation;

namespace Airline.Application.Core.Airplanes.Queries.GetAirplane;

public class GetAirplaneQueryValidator : AbstractValidator<GetAirplaneQuery>
{
    public GetAirplaneQueryValidator()
    {
        RuleFor(airplane => airplane.AirplaneId).NotEqual(Guid.Empty).NotEmpty();
    }
}