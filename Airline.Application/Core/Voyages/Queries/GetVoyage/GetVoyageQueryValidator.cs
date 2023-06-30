using FluentValidation;

namespace Airline.Application.Core.Voyages.Queries.GetVoyage;

public class GetVoyageQueryValidator : AbstractValidator<GetVoyageQuery>
{
    public GetVoyageQueryValidator()
    {
        RuleFor(voyage => voyage.VoyageId).NotEqual(Guid.Empty).NotEmpty();
    }
}