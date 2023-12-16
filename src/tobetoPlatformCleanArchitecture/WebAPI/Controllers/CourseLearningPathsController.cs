using Application.Features.CourseLearningPaths.Commands.Create;
using Application.Features.CourseLearningPaths.Commands.Delete;
using Application.Features.CourseLearningPaths.Commands.Update;
using Application.Features.CourseLearningPaths.Queries.GetById;
using Application.Features.CourseLearningPaths.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseLearningPathsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCourseLearningPathCommand createCourseLearningPathCommand)
    {
        CreatedCourseLearningPathResponse response = await Mediator.Send(createCourseLearningPathCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCourseLearningPathCommand updateCourseLearningPathCommand)
    {
        UpdatedCourseLearningPathResponse response = await Mediator.Send(updateCourseLearningPathCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCourseLearningPathResponse response = await Mediator.Send(new DeleteCourseLearningPathCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCourseLearningPathResponse response = await Mediator.Send(new GetByIdCourseLearningPathQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCourseLearningPathQuery getListCourseLearningPathQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCourseLearningPathListItemDto> response = await Mediator.Send(getListCourseLearningPathQuery);
        return Ok(response);
    }
}