using Application.Features.LearningPaths.Commands.Create;
using Application.Features.LearningPaths.Commands.Delete;
using Application.Features.LearningPaths.Commands.Update;
using Application.Features.LearningPaths.Queries.GetById;
using Application.Features.LearningPaths.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LearningPathsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateLearningPathCommand createLearningPathCommand)
    {
        CreatedLearningPathResponse response = await Mediator.Send(createLearningPathCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateLearningPathCommand updateLearningPathCommand)
    {
        UpdatedLearningPathResponse response = await Mediator.Send(updateLearningPathCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedLearningPathResponse response = await Mediator.Send(new DeleteLearningPathCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdLearningPathResponse response = await Mediator.Send(new GetByIdLearningPathQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLearningPathQuery getListLearningPathQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListLearningPathListItemDto> response = await Mediator.Send(getListLearningPathQuery);
        return Ok(response);
    }
}