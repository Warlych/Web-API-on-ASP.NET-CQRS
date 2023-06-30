using Airline.Application.Core.Hangars.Commands.Create;
using Airline.Application.Core.Hangars.Commands.Delete;
using Airline.Application.Core.Hangars.Commands.Update;
using Airline.Application.Core.Hangars.Queries.GetHangar;
using Airline.Application.Core.Hangars.Queries.GetHangars;
using Airline.Application.Core.Hangars.Queries.Model;
using Airline.Presentation.Controllers.Base;
using Airline.Presentation.Models.Airdrome;
using Airline.Presentation.Models.Hangar;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Presentation.Controllers;

[Route("api/[controller]/[action]")]
public class HangarController : BaseController
{
    private readonly IMapper _mapper;

    public HangarController(IMapper mapper)
        => (_mapper) = (mapper);

    [HttpGet]
    public async Task<ActionResult<HangarDetail[]>> Hangars()
    {
        var hangars = await Mediator.Send(new GetHangarsQuery());
        return Ok(hangars);
    }

    [HttpGet("{hangarId}")]
    public async Task<ActionResult<HangarDetail>> Hangar(Guid hangarId)
    {
        var query = new GetHangarQuery()
        {
            HangarId = hangarId
        };

        var hangar = await Mediator.Send(query);
        return Ok(hangar);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateCommandOfHangar createCommandOfHangar)
    {
        var command = _mapper.Map<CreateCommandOfHangar>(createCommandOfHangar);

        var hangarId = await Mediator.Send(command);
        return Ok(hangarId);
    }

    [HttpPut]
    public async Task<ActionResult<Guid>> Update(UpdateModelOfHangar updateModelOfHangar)
    {
        var command = _mapper.Map<UpdateCommandOfHangar>(updateModelOfHangar);

        var hangarId = await Mediator.Send(command);
        return Ok(hangarId);
    }

    [HttpDelete("{hangarId}")]
    public async Task<ActionResult> Delete(Guid hangarId)
    {
        var command = new DeleteCommandOfHangar()
        {
            HangarId = hangarId
        };

        await Mediator.Send(command);
        return Ok();
    }
}