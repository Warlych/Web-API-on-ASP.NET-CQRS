using Airline.Application.Core.Airdromes.Commands.Update;
using Airline.Application.Interfaces;
using AutoMapper;

namespace Airline.Presentation.Models.Airdrome;

public class UpdateModelOfAirdrome : IMappingTo<UpdateCommandOfAirdrome>
{
    public required Guid AirdromeId { get; set; }
    public required string Name { get; set; }
    public List<Guid> Models { get; set; }
    public required double DowntimeCostPerHour { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateCommandOfAirdrome, UpdateModelOfAirdrome>().ReverseMap();
    }
}