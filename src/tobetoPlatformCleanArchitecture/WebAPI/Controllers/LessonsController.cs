using Application.Features.CourseLearningPaths.Queries.GetListByLearningPathId;
using Application.Features.Lessons.Commands.Create;
using Application.Features.Lessons.Commands.Delete;
using Application.Features.Lessons.Commands.Update;
using Application.Features.Lessons.Commands.Update.UpdateLessonDuration;
using Application.Features.Lessons.Queries.GetById;
using Application.Features.Lessons.Queries.GetList;
using Application.Features.Lessons.Queries.GetListByCourseId;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LessonsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateLessonCommand createLessonCommand)
    {
        CreatedLessonResponse response = await Mediator.Send(createLessonCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateLessonCommand updateLessonCommand)
    {
        UpdatedLessonResponse response = await Mediator.Send(updateLessonCommand);

        return Ok(response);
    }

    [HttpPut("updateLessonDuration")]
    public async Task<IActionResult> UpdateLessonDuration([FromBody] UpdateLessonDurationCommand updateLessonDurationCommand)
    {
        UpdatedLessonResponse response = await Mediator.Send(updateLessonDurationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedLessonResponse response = await Mediator.Send(new DeleteLessonCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdLessonResponse response = await Mediator.Send(new GetByIdLessonQuery { Id = id });
        return Ok(response);
    }

    [HttpGet("getByCourseId/{courseId}")]
    public async Task<IActionResult> GetList([FromRoute] int courseId, [FromQuery] PageRequest pageRequest)
    {
        GetListByCourseIdLessonQuery getListByCourseIdLessonQuery = new() { CourseId = courseId, PageRequest = pageRequest };
        GetListResponse<GetListByCourseIdLessonListItemDto> response = await Mediator.Send(getListByCourseIdLessonQuery);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLessonQuery getListLessonQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListLessonListItemDto> response = await Mediator.Send(getListLessonQuery);
        return Ok(response);
    }
}