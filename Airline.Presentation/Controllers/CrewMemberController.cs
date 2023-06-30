using Airline.Application.Core.CrewMembers.Commands.Create;
using Airline.Application.Core.CrewMembers.Commands.Delete;
using Airline.Application.Core.CrewMembers.Commands.Update;
using Airline.Application.Core.CrewMembers.Queries.GetCrewMemberQuery;
using Airline.Application.Core.CrewMembers.Queries.GetCrewMembers;
using Airline.Application.Core.CrewMembers.Queries.Model;
using Airline.Presentation.Controllers.Base;
using Airline.Presentation.Models.CrewMember;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Airline.Presentation.Controllers;

[Route("api/[controller]/[action]")]
public class CrewMemberController : BaseController
{
    private readonly IMapper _mapper;

    public CrewMemberController(IMapper mapper)
        => (_mapper) = (mapper);

    [HttpGet]
    public async Task<ActionResult<CrewMemberDetail[]>> CrewMembers()
    {
        var members = await Mediator.Send(new GetCrewMembersQuery());
        return Ok(members);
    }

    [HttpGet("{crewMemberId}")]
    public async Task<ActionResult<CrewMemberDetail>> CrewMember(Guid crewMemberId)
    {
        var query = new GetCrewMemberQuery()
        {
            CrewMemberId = crewMemberId
        };

        var member = await Mediator.Send(query);
        return Ok(member);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateModelOfCrewMember createModelOfCrewMember)
    {
        var command = _mapper.Map<CreateCommandOfCrewMember>(createModelOfCrewMember);

        var memberId = await Mediator.Send(command);
        return Ok(memberId);
    }

    [HttpPut]
    public async Task<ActionResult<Guid>> Update(UpdateModelOfCrewMember updateModelOfCrewMember)
    {
        var command = _mapper.Map<UpdateCommandOfCrewMember>(updateModelOfCrewMember);

        var memberId = await Mediator.Send(command);
        return Ok(memberId);
    }

    [HttpDelete("{crewMemberId}")]
    public async Task<ActionResult> Delete(Guid crewMemberId)
    {
        var command = new DeleteCommandOfCrewMember()
        {
            CrewMemberId = crewMemberId
        };

        await Mediator.Send(command);
        return Ok();
    }
}