using Application.Features.AccountCourses.Commands.Create;
using Application.Features.AccountCourses.Commands.Delete;
using Application.Features.AccountCourses.Commands.Update;
using Application.Features.AccountCourses.Queries.GetById;
using Application.Features.AccountCourses.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountCoursesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAccountCourseCommand createAccountCourseCommand)
    {
        CreatedAccountCourseResponse response = await Mediator.Send(createAccountCourseCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAccountCourseCommand updateAccountCourseCommand)
    {
        UpdatedAccountCourseResponse response = await Mediator.Send(updateAccountCourseCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedAccountCourseResponse response = await Mediator.Send(new DeleteAccountCourseCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdAccountCourseResponse response = await Mediator.Send(new GetByIdAccountCourseQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAccountCourseQuery getListAccountCourseQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAccountCourseListItemDto> response = await Mediator.Send(getListAccountCourseQuery);
        return Ok(response);
    }
}