using Airline.Application.Interfaces;
using Airline.Domain;
using AutoMapper;
using MediatR;

namespace Airline.Application.Core.Airdromes.Commands.Create;

public class CreateCommandOfAirdrome : IRequest<Guid>, IMappingTo<Airdrome>
{
    public required string Name { get; set; }
    public required double DowntimeCostPerHour { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCommandOfAirdrome, Airdrome>().ReverseMap();
    }
}