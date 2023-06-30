using Airline.Application.Common.Expections;
using Airline.Application.Core.CrewMembers.Queries.Model;
using Airline.Application.Core.Crews.Queries.Model;
using Airline.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Crews.Queries.GetCrew;

public class GetCrewQueryHandler : IRequestHandler<GetCrewQuery, CrewDetail>
{
    private readonly IDataContext _context;
    private readonly IMapper _mapper;

    public GetCrewQueryHandler(IDataContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<CrewDetail> Handle(GetCrewQuery query, CancellationToken token)
    {
        var crew = await _context.Crews
            .Include(crew => crew.Members)
            .FirstOrDefaultAsync(crew => crew.CrewId == query.CrewId, token);

        if (crew == null)
            throw new NotFoundException(nameof(crew), query.CrewId);

        var members = new List<CrewMemberDetail>();
        foreach (var member in crew.Members)
            members.Add(_mapper.Map<CrewMemberDetail>(member));

        var crewDetail = _mapper.Map<CrewDetail>(crew);
        crewDetail.CrewMembers = members;

        return crewDetail;
    }
}