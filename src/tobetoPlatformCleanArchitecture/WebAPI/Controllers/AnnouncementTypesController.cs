using Application.Features.AnnouncementTypes.Commands.Create;
using Application.Features.AnnouncementTypes.Commands.Delete;
using Application.Features.AnnouncementTypes.Commands.Update;
using Application.Features.AnnouncementTypes.Queries.GetById;
using Application.Features.AnnouncementTypes.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnnouncementTypesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAnnouncementTypeCommand createAnnouncementTypeCommand)
    {
        CreatedAnnouncementTypeResponse response = await Mediator.Send(createAnnouncementTypeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAnnouncementTypeCommand updateAnnouncementTypeCommand)
    {
        UpdatedAnnouncementTypeResponse response = await Mediator.Send(updateAnnouncementTypeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedAnnouncementTypeResponse response = await Mediator.Send(new DeleteAnnouncementTypeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdAnnouncementTypeResponse response = await Mediator.Send(new GetByIdAnnouncementTypeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAnnouncementTypeQuery getListAnnouncementTypeQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAnnouncementTypeListItemDto> response = await Mediator.Send(getListAnnouncementTypeQuery);
        return Ok(response);
    }
}