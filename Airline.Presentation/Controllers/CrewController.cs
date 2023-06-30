using Airline.Application.Core.Crews.Commands.Create;
using Airline.Application.Core.Crews.Commands.Delete;
using Airline.Application.Core.Crews.Commands.Update;
using Airline.Application.Core.Crews.Queries.GetCrew;
using Airline.Application.Core.Crews.Queries.GetCrews;
using Airline.Application.Core.Crews.Queries.Model;
using Airline.Presentation.Controllers.Base;
using Airline.Presentation.Models.Crew;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Presentation.Controllers;

[Route("api/[controller]/[action]")]
public class CrewController : BaseController
{
    private readonly IMapper _mapper;

    public CrewController(IMapper mapper)
        => (_mapper) = (mapper);

    [HttpGet]
    public async Task<ActionResult<CrewDetail[]>> Crews()
    {
        var crews = await Mediator.Send(new GetCrewsQuery());
        return Ok(crews);
    }

    [HttpGet("{crewId}")]
    public async Task<ActionResult<CrewDetail>> Crew(Guid crewId)
    {
        var query = new GetCrewQuery()
        {
            CrewId = crewId
        };

        var crew = await Mediator.Send(query);
        return Ok(crew);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateModelOfCrew createModelOfCrew)
    {
        var command = new CreateCommandOfCrew()
        {
            Name = createModelOfCrew.Name
        };

        var crewId = await Mediator.Send(command);
        return Ok(crewId);
    }

    [HttpPut]
    public async Task<ActionResult<Guid>> Update(UpdateModelOfCrew updateModelOfCrew)
    {
        var command = _mapper.Map<UpdateCommandOfCrew>(updateModelOfCrew);

        var crewId = await Mediator.Send(command);
        return Ok(crewId);
    }
    
    [HttpDelete("{crewId}")]
    public async Task<ActionResult> Delete(Guid crewId)
    {
        var command = new DeleteCommandOfCrew()
        {
            CrewId = crewId
        };

        await Mediator.Send(command);
        return Ok();
    }
}