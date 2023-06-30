using Airline.Application.Core.Voyages.Commands.Create;
using Airline.Application.Core.Voyages.Commands.Delete;
using Airline.Application.Core.Voyages.Commands.Update;
using Airline.Application.Core.Voyages.Queries.GetVoyage;
using Airline.Application.Core.Voyages.Queries.GetVoyages;
using Airline.Application.Core.Voyages.Queries.Model;
using Airline.Application.Core.Voyages.Queries.Occupancy;
using Airline.Application.Core.Voyages.Queries.Profitability;
using Airline.Presentation.Controllers.Base;
using Airline.Presentation.Models.Airplane;
using Airline.Presentation.Models.Voyage;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Presentation.Controllers;

[Route("api/[controller]/[action]")]
public class VoyageController : BaseController
{
    private readonly IMapper _mapper;

    public VoyageController(IMapper mapper)
        => (_mapper) = (mapper);
    
    [HttpGet]
    public async Task<ActionResult<VoyageDetail[]>> Voyages()
    {
        var voyages = await Mediator.Send(new GetVoyagesQuery());
        return Ok(voyages);
    }

    [HttpGet("{voyageId}")]
    public async Task<ActionResult<VoyageDetail>> Voyage(Guid voyageId)
    {
        var command = new GetVoyageQuery()
        {
            VoyageId = voyageId
        };

        var voyage = await Mediator.Send(command);
        return Ok(voyage);
    }    
    
    [HttpGet("{voyageId}")]
    public async Task<ActionResult<double>> Occupancy(Guid voyageId)
    {
        var query = new GetVoyageOccupancyQuery(){VoyageId = voyageId};
        
        var result = await Mediator.Send(query);
        return Ok(result);
    }
    
    [HttpGet("{voyageId}")]
    public async Task<ActionResult<double>> Profitability(Guid voyageId)
    {
        var query = new GetVoyageProfitabilityQuery(){VoyageId = voyageId};
        
        var result = await Mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateModelOfVoyage createModelOfVoyage)
    {
        var command = _mapper.Map<CreateCommandOfVoyage>(createModelOfVoyage);
        
        var voyageId = await Mediator.Send(command);
        return Ok(voyageId);
    }

    [HttpPut]
    public async Task<ActionResult<Guid>> Update(UpdateModelOfVoyage updateModelOfVoyage)
    {
        var command = _mapper.Map<UpdateCommandOfVoyage>(updateModelOfVoyage);

        var voyageId = await Mediator.Send(command);
        return Ok(voyageId);
    }

    [HttpDelete("{voyageId}")]
    public async Task<ActionResult> Delete(Guid voyageId)
    {
        var command = new DeleteCommandOfVoyage()
        {
            VoyageId = voyageId
        };

        await Mediator.Send(command);
        return Ok();
    }
}