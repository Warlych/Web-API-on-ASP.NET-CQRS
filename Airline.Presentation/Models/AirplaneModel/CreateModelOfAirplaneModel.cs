using Airline.Application.Core.AirplaneModels.Commands.Create;
using Airline.Application.Interfaces;
using AutoMapper;

namespace Airline.Presentation.Models.AirplaneModel;

public class CreateModelOfAirplaneModel : IMappingTo<CreateCommandOfAirplaneModel>
{
    public required string ModelName { get; set; }
    public required int CrewCount { get; set; }
    public required int TotalSeats { get; set; }
    public required int RunwayLength { get; set; }
    public required int FuelTankSize { get; set; }
    public required int FuelConsumptionPerHour { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateModelOfAirplaneModel, CreateCommandOfAirplaneModel>().ReverseMap();
    }
}