using Application.Features.AccountRecourses.Commands.Create;
using Application.Features.AccountRecourses.Commands.Delete;
using Application.Features.AccountRecourses.Commands.Update;
using Application.Features.AccountRecourses.Queries.GetById;
using Application.Features.AccountRecourses.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountRecoursesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAccountRecourseCommand createAccountRecourseCommand)
    {
        CreatedAccountRecourseResponse response = await Mediator.Send(createAccountRecourseCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAccountRecourseCommand updateAccountRecourseCommand)
    {
        UpdatedAccountRecourseResponse response = await Mediator.Send(updateAccountRecourseCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedAccountRecourseResponse response = await Mediator.Send(new DeleteAccountRecourseCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdAccountRecourseResponse response = await Mediator.Send(new GetByIdAccountRecourseQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAccountRecourseQuery getListAccountRecourseQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAccountRecourseListItemDto> response = await Mediator.Send(getListAccountRecourseQuery);
        return Ok(response);
    }
}