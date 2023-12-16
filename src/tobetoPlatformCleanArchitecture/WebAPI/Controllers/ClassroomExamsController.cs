using Application.Features.ClassroomExams.Commands.Create;
using Application.Features.ClassroomExams.Commands.Delete;
using Application.Features.ClassroomExams.Commands.Update;
using Application.Features.ClassroomExams.Queries.GetById;
using Application.Features.ClassroomExams.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassroomExamsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateClassroomExamCommand createClassroomExamCommand)
    {
        CreatedClassroomExamResponse response = await Mediator.Send(createClassroomExamCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateClassroomExamCommand updateClassroomExamCommand)
    {
        UpdatedClassroomExamResponse response = await Mediator.Send(updateClassroomExamCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedClassroomExamResponse response = await Mediator.Send(new DeleteClassroomExamCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdClassroomExamResponse response = await Mediator.Send(new GetByIdClassroomExamQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListClassroomExamQuery getListClassroomExamQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListClassroomExamListItemDto> response = await Mediator.Send(getListClassroomExamQuery);
        return Ok(response);
    }
}