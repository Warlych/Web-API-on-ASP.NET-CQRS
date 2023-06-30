using Airline.Application.Core.UsageAirdromeHistories.Commands.Create;
using Airline.Application.Core.UsageAirdromeHistories.Commands.Delete;
using Airline.Application.Core.UsageAirdromeHistories.Commands.Update;
using Airline.Application.Core.UsageAirdromeHistories.Queries.GetAirdromeHistories;
using Airline.Application.Core.UsageAirdromeHistories.Queries.Model;
using Airline.Presentation.Controllers.Base;
using Airline.Presentation.Models.AirdromeHistory;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Presentation.Controllers;

[Route("api/[controller]/[action]")]
public class AirdromeHistoryController : BaseController
{
    private readonly IMapper _mapper;

    public AirdromeHistoryController(IMapper mapper)
        => (_mapper) = (mapper);

    [HttpGet("{airdromeId}")]
    public async Task<ActionResult<AirdromeHistoryDetail[]>> History(Guid airdromeId)
    {
        var query = new GetAirdromeHistoryQuery()
        {
            AirdromeId = airdromeId
        };

        var history = await Mediator.Send(query);
        return Ok(history);
    }
    

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateModelOfHistory createModelOfHistory)
    {
        var command = _mapper.Map<CreateCommandOfAirdromeHistory>(createModelOfHistory);

        var historyId = await Mediator.Send(command);
        return Ok(historyId);
    }

    [HttpPut]
    public async Task<ActionResult<Guid>> Update(UpdateModelOfHistory updateModelOfHistory)
    {
        var command = _mapper.Map<UpdateCommandOfAirdromeHistory>(updateModelOfHistory);

        var historyId = await Mediator.Send(command);
        return Ok(historyId);
    }

    [HttpDelete()]
    public async Task<ActionResult> Delete(DeleteModelOfHistory deleteModelOfHistory)
    {
        var command = _mapper.Map<DeleteCommandOfAirdromeHistory>(deleteModelOfHistory);

        await Mediator.Send(command);
        return Ok();
    }
}