using Airline.Application.Interfaces;
using Airline.Domain;
using AutoMapper;
using MediatR;

namespace Airline.Application.Core.CrewMembers.Commands.Create;

public class CreateCommandHandlerOfCrewMember : IRequestHandler<CreateCommandOfCrewMember, Guid>
{
    private readonly IDataContext _context;
    private readonly IMapper _mapper;

    public CreateCommandHandlerOfCrewMember(IDataContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<Guid> Handle(CreateCommandOfCrewMember request, CancellationToken token)
    {
        var member = _mapper.Map<CrewMember>(request);
        member.CrewMemberId = Guid.NewGuid();

        await _context.CrewMembers.AddAsync(member, token);
        await _context.SaveChangesAsync(token);

        return member.CrewMemberId;
    }
}