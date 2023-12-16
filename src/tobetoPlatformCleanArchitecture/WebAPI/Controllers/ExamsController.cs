using Application.Features.Exams.Commands.Create;
using Application.Features.Exams.Commands.Delete;
using Application.Features.Exams.Commands.Update;
using Application.Features.Exams.Queries.GetById;
using Application.Features.Exams.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExamsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateExamCommand createExamCommand)
    {
        CreatedExamResponse response = await Mediator.Send(createExamCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateExamCommand updateExamCommand)
    {
        UpdatedExamResponse response = await Mediator.Send(updateExamCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedExamResponse response = await Mediator.Send(new DeleteExamCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdExamResponse response = await Mediator.Send(new GetByIdExamQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListExamQuery getListExamQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListExamListItemDto> response = await Mediator.Send(getListExamQuery);
        return Ok(response);
    }
}