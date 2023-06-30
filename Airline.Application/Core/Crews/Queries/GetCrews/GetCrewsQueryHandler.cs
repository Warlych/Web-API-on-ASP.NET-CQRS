using Airline.Application.Core.CrewMembers.Queries.Model;
using Airline.Application.Core.Crews.Queries.Model;
using Airline.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Crews.Queries.GetCrews;

public class GetCrewsQueryHandler : IRequestHandler<GetCrewsQuery, CrewDetail[]>
{
    private readonly IDataContext _context;
    private readonly IMapper _mapper;

    public GetCrewsQueryHandler(IDataContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<CrewDetail[]> Handle(GetCrewsQuery query, CancellationToken token)
    {
        var crews = new List<CrewDetail>();

        await _context.Crews
            .Include(crew => crew.Members)
            .ForEachAsync(crew =>
            {
                var members = new List<CrewMemberDetail>();
                foreach (var member in crew.Members)
                    members.Add(_mapper.Map<CrewMemberDetail>(member));

                var crewDetail = _mapper.Map<CrewDetail>(crew);
                crewDetail.CrewMembers = members;

                crews.Add(crewDetail);
            }, token);

        return crews.ToArray();
    }
}