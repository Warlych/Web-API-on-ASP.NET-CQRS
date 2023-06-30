using Airline.Application.Common.Expections;
using Airline.Application.Interfaces;
using Airline.Domain;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Airline.Application.Core.Hangars.Commands.Create;

public class CreateCommandHandlerOfHangar : IRequestHandler<CreateCommandOfHangar, Guid>
{
    private readonly IDataContext _context;
    private readonly IMapper _mapper;

    public CreateCommandHandlerOfHangar(IDataContext context, IMapper mapper)
        => (_context, _mapper) = (context, mapper);

    public async Task<Guid> Handle(CreateCommandOfHangar request, CancellationToken token)
    {
        var hangar = _mapper.Map<Hangar>(request);
        hangar.HangarId = Guid.NewGuid();

        await _context.Hangars.AddAsync(hangar, token);
        await _context.SaveChangesAsync(token);
        
        return hangar.HangarId;
    }
}