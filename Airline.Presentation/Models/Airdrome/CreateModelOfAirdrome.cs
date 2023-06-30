using Airline.Application.Core.Airdromes.Commands.Create;
using Airline.Application.Interfaces;
using AutoMapper;

namespace Airline.Presentation.Models.Airdrome;

public class CreateModelOfAirdrome : IMappingTo<CreateCommandOfAirdrome>
{
    public required string Name { get; set; }
    public required double DowntimeCostPerHour { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateModelOfAirdrome, CreateCommandOfAirdrome>().ReverseMap();
    }
}