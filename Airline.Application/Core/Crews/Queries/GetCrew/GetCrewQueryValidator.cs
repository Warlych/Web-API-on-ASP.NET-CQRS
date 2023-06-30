using FluentValidation;

namespace Airline.Application.Core.Crews.Queries.GetCrew;

public class GetCrewQueryValidator : AbstractValidator<GetCrewQuery>
{
    public GetCrewQueryValidator()
    {
        RuleFor(crew => crew.CrewId).NotEqual(Guid.Empty).NotEmpty();
    }
}