using Application.Features.RecourseDetailSteps.Commands.Create;
using Application.Features.RecourseDetailSteps.Commands.Delete;
using Application.Features.RecourseDetailSteps.Commands.Update;
using Application.Features.RecourseDetailSteps.Queries.GetById;
using Application.Features.RecourseDetailSteps.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecourseDetailStepsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateRecourseDetailStepCommand createRecourseDetailStepCommand)
    {
        CreatedRecourseDetailStepResponse response = await Mediator.Send(createRecourseDetailStepCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRecourseDetailStepCommand updateRecourseDetailStepCommand)
    {
        UpdatedRecourseDetailStepResponse response = await Mediator.Send(updateRecourseDetailStepCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedRecourseDetailStepResponse response = await Mediator.Send(new DeleteRecourseDetailStepCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdRecourseDetailStepResponse response = await Mediator.Send(new GetByIdRecourseDetailStepQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRecourseDetailStepQuery getListRecourseDetailStepQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListRecourseDetailStepListItemDto> response = await Mediator.Send(getListRecourseDetailStepQuery);
        return Ok(response);
    }
}