using Airline.Domain;
using Airline.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Airline.Application.Core.AirplaneModels.Commands.Create;

public class CreateCommandHandlerOfAirplaneModel : IRequestHandler<CreateCommandOfAirplaneModel, Guid>
{
    private readonly IDataContext _context;
    private readonly IMapper _mapper;

    public CreateCommandHandlerOfAirplaneModel(IDataContext data, IMapper mapper) =>
        (_context, _mapper) = (data, mapper);

    public async Task<Guid> Handle(CreateCommandOfAirplaneModel request, CancellationToken token)
    {
        var airplaneModel = _mapper.Map<AirplaneModel>(request);

        await _context.AirplaneModels.AddAsync(airplaneModel, token);
        await _context.SaveChangesAsync(token);
        
        return airplaneModel.ModelId;
    }
}