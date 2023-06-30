using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using FluentValidation;

namespace Airline.Application.Core.CrewMembers.Commands.Update;

public class UpdateCommandValidatorOfCrewMember : AbstractValidator<UpdateCommandOfCrewMember>
{
    private readonly IDataContext _context;
    
    public UpdateCommandValidatorOfCrewMember(IDataContext context)
    {
        _context = context;

        RuleFor(member => member.CrewMemberId).NotEqual(Guid.Empty).NotEmpty();
        RuleFor(member => member.FullName).NotEmpty();
        RuleFor(member => member.PhoneNumber).NotEmpty();
        RuleFor(member => member.Salary).NotEmpty();
        RuleFor(member => member.JobTitle).NotEmpty();
        RuleFor(member => member.CrewId).NotEqual(Guid.Empty).NotEmpty();
        RuleFor(member => member).Must((member) =>
        {
            return IsCrewExists(member);
        });
    }

    private bool IsCrewExists(UpdateCommandOfCrewMember request)
    {
        var crew = _context.Crews
            .FirstOrDefault(crew => crew.CrewId == request.CrewId);

        if (crew == null)
            throw new NotFoundException(nameof(crew), request.CrewId);

        return true;
    }
}