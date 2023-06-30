using FluentValidation;

namespace Airline.Application.Core.CrewMembers.Queries.GetCrewMemberQuery;

public class GetCrewMemberQueryValidator : AbstractValidator<GetCrewMemberQuery>
{
    public GetCrewMemberQueryValidator()
    {
        RuleFor(member => member.CrewMemberId).NotEqual(Guid.Empty).NotEmpty();
    }
}