using Airline.Application.Common.Expections;
using Airline.Application.Core.Voyages.Queries.Model;
using Airline.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Voyages.Queries.GetVoyage;

public class GetVoyageQueryHandler : IRequestHandler<GetVoyageQuery, VoyageDetail>
{
    private readonly IDataContext _context;
    private readonly IMapper _mapper;

    public GetVoyageQueryHandler(IDataContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<VoyageDetail> Handle(GetVoyageQuery query, CancellationToken token)
    {
        var entity = await _context.Voyages.FirstOrDefaultAsync(voyage
            => voyage.VoyageId == query.VoyageId, token);

        if (entity == null)
            throw new NotFoundException(nameof(entity), query.VoyageId);

        return _mapper.Map<VoyageDetail>(entity);
    }
}