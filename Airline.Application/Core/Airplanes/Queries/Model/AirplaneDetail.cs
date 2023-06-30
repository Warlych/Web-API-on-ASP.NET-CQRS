using Airline.Application.Interfaces;
using Airline.Domain;
using AutoMapper;

namespace Airline.Application.Core.Airplanes.Queries.Model;

public class AirplaneDetail : IMappingTo<Airplane>
{
    public required Guid AirplaneId { get; set; }
    public required string Name { get; set; }
    public required Guid ModelId { get; set; }

    public required Guid CurrentCrewId { get; set; }
    public required List<Voyage> Voyages { get; set; }
    public required List<Airdrome> UsedAirdromes { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<AirplaneDetail, Airplane>().ReverseMap();
    }
}