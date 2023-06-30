using Airline.Application.Core.Airplanes.Commands.Create;
using Airline.Application.Core.Airplanes.Commands.Delete;
using Airline.Application.Core.Airplanes.Commands.Update;
using Airline.Application.Core.Airplanes.Queries.FlightOfTheAirplane;
using Airline.Application.Core.Airplanes.Queries.GetAirplane;
using Airline.Application.Core.Airplanes.Queries.GetAirplanes;
using Airline.Application.Core.Airplanes.Queries.Model;
using Airline.Presentation.Controllers.Base;
using Airline.Presentation.Models.Airplane;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Presentation.Controllers;

[Route("api/[controller]/[action]")]
public class AirplaneController : BaseController
{
    private readonly IMapper _mapper;

    public AirplaneController(IMapper mapper)
        => (_mapper) = (mapper);

    [HttpGet]
    public async Task<ActionResult<AirplaneDetail[]>> Airplanes()
    {
        var airplanes = await Mediator.Send(new GetAirplanesQuery());
        return Ok(airplanes);
    }

    [HttpGet("{airplaneId}")]
    public async Task<ActionResult<AirplaneDetail>> Airplane(Guid airplaneId)
    {
        var command = new GetAirplaneQuery()
        {
            AirplaneId = airplaneId
        };

        var airplane = await Mediator.Send(command);
        return Ok(airplane);
    }
    
    [HttpGet("{airplaneId}")]
    public async Task<ActionResult<Dictionary<string, double>>> Quantity(Guid airplaneId)
    {
        var command = new GetQuantityFlyingKilometresQuery()
        {
            AirplaneId = airplaneId
        };

        var result = await Mediator.Send(command);
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<ActionResult<Dictionary<string, double>>> QuantityAll()
    {
        var command = new GetQuantityFlyingKilometresQuery();

        var result = await Mediator.Send(command);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateModelOfAirplane createModelOfAirplane)
    {
        var command = _mapper.Map<CreateCommandOfAirplane>(createModelOfAirplane);

        var airplaneId = await Mediator.Send(command);
        return Ok(airplaneId);
    }

    [HttpPut]
    public async Task<ActionResult<Guid>> Update(UpdateModelOfAirplane updateModelOfAirplane)
    {
        var command = _mapper.Map<UpdateCommandOfAirplane>(updateModelOfAirplane);
        
        var airplaneId = await Mediator.Send(command);
        return Ok(airplaneId);
    }

    [HttpDelete("{airplaneId}")]
    public async Task<ActionResult> Delete(Guid airplaneId)
    {
        var command = new DeleteCommandOfAirplane()
        {
            AirplaneId = airplaneId
        };

        await Mediator.Send(command);
        return Ok();
    }
}