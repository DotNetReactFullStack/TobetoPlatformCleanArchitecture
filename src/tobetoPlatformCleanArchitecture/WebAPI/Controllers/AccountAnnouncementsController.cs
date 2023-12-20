using Application.Features.AccountAnnouncements.Commands.Create;
using Application.Features.AccountAnnouncements.Commands.Delete;
using Application.Features.AccountAnnouncements.Commands.Update;
using Application.Features.AccountAnnouncements.Queries.GetById;
using Application.Features.AccountAnnouncements.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountAnnouncementsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAccountAnnouncementCommand createAccountAnnouncementCommand)
    {
        CreatedAccountAnnouncementResponse response = await Mediator.Send(createAccountAnnouncementCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAccountAnnouncementCommand updateAccountAnnouncementCommand)
    {
        UpdatedAccountAnnouncementResponse response = await Mediator.Send(updateAccountAnnouncementCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedAccountAnnouncementResponse response = await Mediator.Send(new DeleteAccountAnnouncementCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdAccountAnnouncementResponse response = await Mediator.Send(new GetByIdAccountAnnouncementQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAccountAnnouncementQuery getListAccountAnnouncementQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAccountAnnouncementListItemDto> response = await Mediator.Send(getListAccountAnnouncementQuery);
        return Ok(response);
    }
}