using Airline.Application.Common.Expections;
using Airline.Application.Core.CrewMembers.Queries.Model;
using Airline.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.CrewMembers.Queries.GetCrewMemberQuery;

public class GetCrewMemberQueryHandler : IRequestHandler<GetCrewMemberQuery, CrewMemberDetail>
{
    private readonly IDataContext _context;
    private readonly IMapper _mapper;

    public GetCrewMemberQueryHandler(IDataContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<CrewMemberDetail> Handle(GetCrewMemberQuery query, CancellationToken token)
    {
        var member = await _context.CrewMembers
            .FirstOrDefaultAsync(member => member.CrewMemberId == query.CrewMemberId, token);

        if (member == null)
            throw new NotFoundException(nameof(member), query.CrewMemberId);

        return _mapper.Map<CrewMemberDetail>(member);
    }
}