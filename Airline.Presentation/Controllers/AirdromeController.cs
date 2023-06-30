using Airline.Application.Core.Airdromes.Commands.Create;
using Airline.Application.Core.Airdromes.Commands.Delete;
using Airline.Application.Core.Airdromes.Commands.Update;
using Airline.Application.Core.Airdromes.Queries.GetAirdrome;
using Airline.Application.Core.Airdromes.Queries.GetAirdromes;
using Airline.Application.Core.Airdromes.Queries.Model;
using Airline.Presentation.Controllers.Base;
using Airline.Presentation.Models.Airdrome;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Presentation.Controllers;

[Route("api/[controller]/[action]")]
public class AirdromeController : BaseController
{
    private readonly IMapper _mapper;

    public AirdromeController(IMapper mapper)
        => (_mapper) = (mapper);

    [HttpGet]
    public async Task<ActionResult<AirdromeDetail[]>> Airdromes()
    {
        var airdromes = await Mediator.Send(new GetAirdromesQuery());
        return Ok(airdromes);
    }

    [HttpGet("{airdromeId}")]
    public async Task<ActionResult<AirdromeDetail>> Airdrome(Guid airdromeId)
    {
        var query = new GetAirdromeQuery()
        {
            AirdromeId = airdromeId
        };

        var airdrome = await Mediator.Send(query);
        return Ok(airdrome);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateModelOfAirdrome createModelOfAirdrome)
    {
        var command = _mapper.Map<CreateCommandOfAirdrome>(createModelOfAirdrome);

        var airdromeId = await Mediator.Send(command);
        return Ok(airdromeId);
    }

    [HttpPut]
    public async Task<ActionResult<Guid>> Update(UpdateModelOfAirdrome updateModelOfAirdrome)
    {
        var command = _mapper.Map<UpdateCommandOfAirdrome>(updateModelOfAirdrome);

        var airdromeId = await Mediator.Send(command);
        return Ok(airdromeId);
    }

    [HttpDelete("{airdromeId}")]
    public async Task<ActionResult> Delete(Guid airdromeId)
    {
        var command = new DeleteCommandOfAirdrome()
        {
            AirdromeId = airdromeId
        };

        await Mediator.Send(command);
        return Ok();
    }
}