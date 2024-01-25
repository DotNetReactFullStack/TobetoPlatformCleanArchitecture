using Application.Features.RecourseDetails.Commands.Create;
using Application.Features.RecourseDetails.Commands.Delete;
using Application.Features.RecourseDetails.Commands.Update;
using Application.Features.RecourseDetails.Queries.GetById;
using Application.Features.RecourseDetails.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecourseDetailsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateRecourseDetailCommand createRecourseDetailCommand)
    {
        CreatedRecourseDetailResponse response = await Mediator.Send(createRecourseDetailCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRecourseDetailCommand updateRecourseDetailCommand)
    {
        UpdatedRecourseDetailResponse response = await Mediator.Send(updateRecourseDetailCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedRecourseDetailResponse response = await Mediator.Send(new DeleteRecourseDetailCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdRecourseDetailResponse response = await Mediator.Send(new GetByIdRecourseDetailQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRecourseDetailQuery getListRecourseDetailQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListRecourseDetailListItemDto> response = await Mediator.Send(getListRecourseDetailQuery);
        return Ok(response);
    }
}