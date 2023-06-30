using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using Airline.Domain;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Airplanes.Commands.Create;

public class CreateCommandHandlerOfAirplane : IRequestHandler<CreateCommandOfAirplane, Guid>
{
    private readonly IDataContext _context;
    private readonly IMapper _mapper;

    public CreateCommandHandlerOfAirplane(IDataContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);
    
    public async Task<Guid> Handle(CreateCommandOfAirplane request, CancellationToken token)
    {
        var airplane = _mapper.Map<Airplane>(request);
        airplane.AirplaneId = Guid.NewGuid();

        await _context.Airplanes.AddAsync(airplane, token);
        await _context.SaveChangesAsync(token);

        return airplane.AirplaneId;
    }
}