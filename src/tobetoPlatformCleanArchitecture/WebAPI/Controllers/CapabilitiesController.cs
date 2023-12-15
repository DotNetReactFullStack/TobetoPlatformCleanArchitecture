using Application.Features.Capabilities.Commands.Create;
using Application.Features.Capabilities.Commands.Delete;
using Application.Features.Capabilities.Commands.Update;
using Application.Features.Capabilities.Queries.GetById;
using Application.Features.Capabilities.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CapabilitiesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCapabilityCommand createCapabilityCommand)
    {
        CreatedCapabilityResponse response = await Mediator.Send(createCapabilityCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCapabilityCommand updateCapabilityCommand)
    {
        UpdatedCapabilityResponse response = await Mediator.Send(updateCapabilityCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCapabilityResponse response = await Mediator.Send(new DeleteCapabilityCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCapabilityResponse response = await Mediator.Send(new GetByIdCapabilityQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCapabilityQuery getListCapabilityQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCapabilityListItemDto> response = await Mediator.Send(getListCapabilityQuery);
        return Ok(response);
    }
}