using Application.Features.Recourses.Commands.Create;
using Application.Features.Recourses.Commands.Delete;
using Application.Features.Recourses.Commands.Update;
using Application.Features.Recourses.Queries.GetById;
using Application.Features.Recourses.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecoursesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateRecourseCommand createRecourseCommand)
    {
        CreatedRecourseResponse response = await Mediator.Send(createRecourseCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRecourseCommand updateRecourseCommand)
    {
        UpdatedRecourseResponse response = await Mediator.Send(updateRecourseCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedRecourseResponse response = await Mediator.Send(new DeleteRecourseCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdRecourseResponse response = await Mediator.Send(new GetByIdRecourseQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRecourseQuery getListRecourseQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListRecourseListItemDto> response = await Mediator.Send(getListRecourseQuery);
        return Ok(response);
    }
}