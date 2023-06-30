using Airline.Application.Core.CrewMembers.Queries.Model;
using Airline.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.CrewMembers.Queries.GetCrewMembers;

public class GetCrewMemberQueryHandler : IRequestHandler<GetCrewMembersQuery, CrewMemberDetail[]>
{
    private readonly IDataContext _context;
    private readonly IMapper _mapper;

    public GetCrewMemberQueryHandler(IDataContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<CrewMemberDetail[]> Handle(GetCrewMembersQuery query, CancellationToken token)
    {
        var members = new List<CrewMemberDetail>();

        await _context.CrewMembers
            .ForEachAsync(member =>
            {
                members.Add(_mapper.Map<CrewMemberDetail>(member));
            }, token);

        return members.ToArray();
    }
}