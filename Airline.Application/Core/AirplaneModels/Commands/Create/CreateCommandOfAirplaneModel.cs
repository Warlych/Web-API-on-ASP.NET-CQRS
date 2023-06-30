using Airline.Application.Interfaces;
using Airline.Domain;
using AutoMapper;
using MediatR;

namespace Airline.Application.Core.AirplaneModels.Commands.Create;

public class CreateCommandOfAirplaneModel : IRequest<Guid>, IMappingTo<AirplaneModel>
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
        profile.CreateMap<AirplaneModel, CreateCommandOfAirplaneModel>().ReverseMap();
    }
}