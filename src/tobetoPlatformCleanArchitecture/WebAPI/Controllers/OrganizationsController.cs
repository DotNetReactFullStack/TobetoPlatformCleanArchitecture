using Application.Features.Organizations.Commands.Create;
using Application.Features.Organizations.Commands.Delete;
using Application.Features.Organizations.Commands.Update;
using Application.Features.Organizations.Queries.GetById;
using Application.Features.Organizations.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrganizationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateOrganizationCommand createOrganizationCommand)
    {
        CreatedOrganizationResponse response = await Mediator.Send(createOrganizationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOrganizationCommand updateOrganizationCommand)
    {
        UpdatedOrganizationResponse response = await Mediator.Send(updateOrganizationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedOrganizationResponse response = await Mediator.Send(new DeleteOrganizationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdOrganizationResponse response = await Mediator.Send(new GetByIdOrganizationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListOrganizationQuery getListOrganizationQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListOrganizationListItemDto> response = await Mediator.Send(getListOrganizationQuery);
        return Ok(response);
    }
}