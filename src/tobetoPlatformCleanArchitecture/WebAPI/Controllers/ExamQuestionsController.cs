using Application.Features.ExamQuestions.Commands.Create;
using Application.Features.ExamQuestions.Commands.Delete;
using Application.Features.ExamQuestions.Commands.Update;
using Application.Features.ExamQuestions.Queries.GetById;
using Application.Features.ExamQuestions.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExamQuestionsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateExamQuestionCommand createExamQuestionCommand)
    {
        CreatedExamQuestionResponse response = await Mediator.Send(createExamQuestionCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateExamQuestionCommand updateExamQuestionCommand)
    {
        UpdatedExamQuestionResponse response = await Mediator.Send(updateExamQuestionCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedExamQuestionResponse response = await Mediator.Send(new DeleteExamQuestionCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdExamQuestionResponse response = await Mediator.Send(new GetByIdExamQuestionQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListExamQuestionQuery getListExamQuestionQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListExamQuestionListItemDto> response = await Mediator.Send(getListExamQuestionQuery);
        return Ok(response);
    }
}