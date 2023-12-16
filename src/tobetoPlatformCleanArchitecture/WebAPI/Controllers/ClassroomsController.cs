using Application.Features.Classrooms.Commands.Create;
using Application.Features.Classrooms.Commands.Delete;
using Application.Features.Classrooms.Commands.Update;
using Application.Features.Classrooms.Queries.GetById;
using Application.Features.Classrooms.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassroomsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateClassroomCommand createClassroomCommand)
    {
        CreatedClassroomResponse response = await Mediator.Send(createClassroomCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateClassroomCommand updateClassroomCommand)
    {
        UpdatedClassroomResponse response = await Mediator.Send(updateClassroomCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedClassroomResponse response = await Mediator.Send(new DeleteClassroomCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdClassroomResponse response = await Mediator.Send(new GetByIdClassroomQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListClassroomQuery getListClassroomQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListClassroomListItemDto> response = await Mediator.Send(getListClassroomQuery);
        return Ok(response);
    }
}