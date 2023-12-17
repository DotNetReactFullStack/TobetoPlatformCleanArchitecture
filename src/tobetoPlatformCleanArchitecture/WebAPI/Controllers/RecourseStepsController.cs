using Application.Features.RecourseSteps.Commands.Create;
using Application.Features.RecourseSteps.Commands.Delete;
using Application.Features.RecourseSteps.Commands.Update;
using Application.Features.RecourseSteps.Queries.GetById;
using Application.Features.RecourseSteps.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecourseStepsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateRecourseStepCommand createRecourseStepCommand)
    {
        CreatedRecourseStepResponse response = await Mediator.Send(createRecourseStepCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRecourseStepCommand updateRecourseStepCommand)
    {
        UpdatedRecourseStepResponse response = await Mediator.Send(updateRecourseStepCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedRecourseStepResponse response = await Mediator.Send(new DeleteRecourseStepCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdRecourseStepResponse response = await Mediator.Send(new GetByIdRecourseStepQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRecourseStepQuery getListRecourseStepQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListRecourseStepListItemDto> response = await Mediator.Send(getListRecourseStepQuery);
        return Ok(response);
    }
}