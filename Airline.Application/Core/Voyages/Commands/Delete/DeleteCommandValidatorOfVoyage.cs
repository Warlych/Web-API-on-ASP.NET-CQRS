using Airline.Application.Interfaces;
using FluentValidation;

namespace Airline.Application.Core.Voyages.Commands.Delete;

public class DeleteCommandValidatorOfVoyage : AbstractValidator<DeleteCommandOfVoyage>
{
    private readonly IDataContext _context;
    public DeleteCommandValidatorOfVoyage(IDataContext context)
    {
        _context = context;
        
        RuleFor(voyage => voyage.VoyageId).NotEqual(Guid.Empty).NotEmpty();
        RuleFor(voyage => voyage).Must(request =>
        {
            var voyage = _context.Voyages.FirstOrDefault(voyage => voyage.VoyageId == request.VoyageId);

            return voyage.FlightDate.Equals(DateTime.Now);
        });
    }
}