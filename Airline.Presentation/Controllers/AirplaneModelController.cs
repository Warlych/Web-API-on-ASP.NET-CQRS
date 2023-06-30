using Airline.Application.Core.AirplaneModels.Commands.Create;
using Airline.Application.Core.AirplaneModels.Commands.Delete;
using Airline.Application.Core.AirplaneModels.Commands.Update;
using Airline.Application.Core.AirplaneModels.Queries.GetModel;
using Airline.Application.Core.AirplaneModels.Queries.GetModels;
using Airline.Application.Core.AirplaneModels.Queries.Model;
using Airline.Presentation.Controllers.Base;
using Airline.Presentation.Models.AirplaneModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Presentation.Controllers;

[Route("api/[controller]/[action]")]
public class AirplaneModelController : BaseController
{
    private readonly IMapper _mapper;

    public AirplaneModelController(IMapper mapper)
        => (_mapper) = (mapper);

    [HttpGet]
    public async Task<ActionResult<AirplaneModelDetail[]>> Models()
    {
        var airplaneModels = await Mediator.Send(new GetAirplaneModelsQuery());
        return Ok(airplaneModels);
    }
    
    [HttpGet("{modelId}")]
    public async Task<ActionResult<AirplaneModelDetail>> Model(Guid modelId)
    {
        var query = new GetAirplaneModelQuery()
        {
            ModelId = modelId
        };

        var model = await Mediator.Send(query);
        return Ok(model);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateModelOfAirplaneModel createModelOfAirplaneModel)
    {
        var command = _mapper.Map<CreateCommandOfAirplaneModel>(createModelOfAirplaneModel);
        
        var modelId = await Mediator.Send(command);
        return Ok(modelId);
    }

    [HttpPut]
    public async Task<ActionResult<Guid>> Update(UpdateModelOfAirplaneModel updateModelOfAirplaneModel)
    {
        var command = _mapper.Map<UpdateCommandOfAirplaneModel>(updateModelOfAirplaneModel);
        
        var modelId = await Mediator.Send(command);
        return Ok(modelId);
    }

    [HttpDelete("{modelId}")]
    public async Task<ActionResult> Delete(Guid modelId)
    {
        var command = new DeleteCommandOfAirplaneModel()
        {
            ModelId = modelId
        };
        
        await Mediator.Send(command);
        return NoContent();
    }
}