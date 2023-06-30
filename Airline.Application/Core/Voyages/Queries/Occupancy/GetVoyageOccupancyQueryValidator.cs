using FluentValidation;

namespace Airline.Application.Core.Voyages.Queries.Occupancy;

public class GetVoyageOccupancyQueryValidator : AbstractValidator<GetVoyageOccupancyQuery>
{
    public GetVoyageOccupancyQueryValidator()
    {
        RuleFor(voyage => voyage.VoyageId).NotEqual(Guid.Empty).NotEmpty();
    }
}