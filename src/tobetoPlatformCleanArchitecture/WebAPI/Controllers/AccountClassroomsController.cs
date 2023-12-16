using Application.Features.AccountClassrooms.Commands.Create;
using Application.Features.AccountClassrooms.Commands.Delete;
using Application.Features.AccountClassrooms.Commands.Update;
using Application.Features.AccountClassrooms.Queries.GetById;
using Application.Features.AccountClassrooms.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountClassroomsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAccountClassroomCommand createAccountClassroomCommand)
    {
        CreatedAccountClassroomResponse response = await Mediator.Send(createAccountClassroomCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAccountClassroomCommand updateAccountClassroomCommand)
    {
        UpdatedAccountClassroomResponse response = await Mediator.Send(updateAccountClassroomCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedAccountClassroomResponse response = await Mediator.Send(new DeleteAccountClassroomCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdAccountClassroomResponse response = await Mediator.Send(new GetByIdAccountClassroomQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAccountClassroomQuery getListAccountClassroomQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAccountClassroomListItemDto> response = await Mediator.Send(getListAccountClassroomQuery);
        return Ok(response);
    }
}