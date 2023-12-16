using Application.Features.Answers.Commands.Create;
using Application.Features.Answers.Commands.Delete;
using Application.Features.Answers.Commands.Update;
using Application.Features.Answers.Queries.GetById;
using Application.Features.Answers.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnswersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAnswerCommand createAnswerCommand)
    {
        CreatedAnswerResponse response = await Mediator.Send(createAnswerCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAnswerCommand updateAnswerCommand)
    {
        UpdatedAnswerResponse response = await Mediator.Send(updateAnswerCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedAnswerResponse response = await Mediator.Send(new DeleteAnswerCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdAnswerResponse response = await Mediator.Send(new GetByIdAnswerQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAnswerQuery getListAnswerQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAnswerListItemDto> response = await Mediator.Send(getListAnswerQuery);
        return Ok(response);
    }
}