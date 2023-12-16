using Application.Features.OrganizationTypes.Commands.Create;
using Application.Features.OrganizationTypes.Commands.Delete;
using Application.Features.OrganizationTypes.Commands.Update;
using Application.Features.OrganizationTypes.Queries.GetById;
using Application.Features.OrganizationTypes.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrganizationTypesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateOrganizationTypeCommand createOrganizationTypeCommand)
    {
        CreatedOrganizationTypeResponse response = await Mediator.Send(createOrganizationTypeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOrganizationTypeCommand updateOrganizationTypeCommand)
    {
        UpdatedOrganizationTypeResponse response = await Mediator.Send(updateOrganizationTypeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedOrganizationTypeResponse response = await Mediator.Send(new DeleteOrganizationTypeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdOrganizationTypeResponse response = await Mediator.Send(new GetByIdOrganizationTypeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListOrganizationTypeQuery getListOrganizationTypeQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListOrganizationTypeListItemDto> response = await Mediator.Send(getListOrganizationTypeQuery);
        return Ok(response);
    }
}