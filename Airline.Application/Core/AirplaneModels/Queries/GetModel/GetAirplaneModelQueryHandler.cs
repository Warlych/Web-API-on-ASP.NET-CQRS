using Airline.Application.Common.Expections;
using Airline.Application.Core.AirplaneModels.Queries.Model;
using Airline.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.AirplaneModels.Queries.GetModel;

public class GetAirplaneModelQueryHandler : IRequestHandler<GetAirplaneModelQuery, AirplaneModelDetail>
{
    private readonly IDataContext _context;
    private readonly IMapper _mapper;
    
    public GetAirplaneModelQueryHandler(IDataContext context, IMapper mapper) =>
        (_context, _mapper) = (context, mapper);

    public async Task<AirplaneModelDetail> Handle(GetAirplaneModelQuery query, CancellationToken token)
    {
        var model = await _context.AirplaneModels
            .FirstOrDefaultAsync(model => model.ModelId == query.ModelId);

        if (model == null)
            throw new NotFoundException(nameof(model), query.ModelId);

        return _mapper.Map<AirplaneModelDetail>(model);
    }
}