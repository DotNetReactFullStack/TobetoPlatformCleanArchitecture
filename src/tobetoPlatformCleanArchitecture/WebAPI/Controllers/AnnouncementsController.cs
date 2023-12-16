using Application.Features.Announcements.Commands.Create;
using Application.Features.Announcements.Commands.Delete;
using Application.Features.Announcements.Commands.Update;
using Application.Features.Announcements.Queries.GetById;
using Application.Features.Announcements.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnnouncementsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAnnouncementCommand createAnnouncementCommand)
    {
        CreatedAnnouncementResponse response = await Mediator.Send(createAnnouncementCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAnnouncementCommand updateAnnouncementCommand)
    {
        UpdatedAnnouncementResponse response = await Mediator.Send(updateAnnouncementCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedAnnouncementResponse response = await Mediator.Send(new DeleteAnnouncementCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdAnnouncementResponse response = await Mediator.Send(new GetByIdAnnouncementQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAnnouncementQuery getListAnnouncementQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAnnouncementListItemDto> response = await Mediator.Send(getListAnnouncementQuery);
        return Ok(response);
    }
}