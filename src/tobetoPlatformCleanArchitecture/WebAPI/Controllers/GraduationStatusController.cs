using Application.Features.GraduationStatuses.Commands.Create;
using Application.Features.GraduationStatuses.Commands.Delete;
using Application.Features.GraduationStatuses.Commands.Update;
using Application.Features.GraduationStatuses.Queries.GetById;
using Application.Features.GraduationStatuses.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GraduationStatusController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateGraduationStatusCommand createGraduationStatusCommand)
    {
        CreatedGraduationStatusResponse response = await Mediator.Send(createGraduationStatusCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateGraduationStatusCommand updateGraduationStatusCommand)
    {
        UpdatedGraduationStatusResponse response = await Mediator.Send(updateGraduationStatusCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedGraduationStatusResponse response = await Mediator.Send(new DeleteGraduationStatusCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdGraduationStatusResponse response = await Mediator.Send(new GetByIdGraduationStatusQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListGraduationStatusQuery getListGraduationStatusQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListGraduationStatusListItemDto> response = await Mediator.Send(getListGraduationStatusQuery);
        return Ok(response);
    }
}