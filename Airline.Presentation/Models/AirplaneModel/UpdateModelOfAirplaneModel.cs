using Airline.Application.Core.AirplaneModels.Commands.Update;
using Airline.Application.Interfaces;
using AutoMapper;

namespace Airline.Presentation.Models.AirplaneModel;

public class UpdateModelOfAirplaneModel : IMappingTo<UpdateCommandOfAirplaneModel>
{
    public required Guid ModelId { get; set; }
    public required string ModelName { get; set; }
    public required int CrewCount { get; set; }
    public required int TotalSeats { get; set; }
    public required int RunwayLength { get; set; }
    public required int FuelTankSize { get; set; }
    public required int FuelConsumptionPerHour { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateModelOfAirplaneModel, UpdateCommandOfAirplaneModel>().ReverseMap();
    }
}