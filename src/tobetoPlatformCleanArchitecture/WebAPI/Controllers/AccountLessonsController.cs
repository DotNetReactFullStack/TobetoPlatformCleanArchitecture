using Application.Features.AccountLessons.Commands.Create;
using Application.Features.AccountLessons.Commands.Delete;
using Application.Features.AccountLessons.Commands.Update;
using Application.Features.AccountLessons.Queries.GetById;
using Application.Features.AccountLessons.Queries.GetList;
using Application.Features.AccountLessons.Queries.GetListByAccountIdAndLessonId;
using Application.Features.CourseLearningPaths.Queries.GetListByLearningPathId;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountLessonsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAccountLessonCommand createAccountLessonCommand)
    {
        CreatedAccountLessonResponse response = await Mediator.Send(createAccountLessonCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAccountLessonCommand updateAccountLessonCommand)
    {
        UpdatedAccountLessonResponse response = await Mediator.Send(updateAccountLessonCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedAccountLessonResponse response = await Mediator.Send(new DeleteAccountLessonCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdAccountLessonResponse response = await Mediator.Send(new GetByIdAccountLessonQuery { Id = id });
        return Ok(response);
    }

    [HttpGet("GetAccountIdAndLessonId{accountId}/{lessonId}")]
    public async Task<IActionResult> GetById([FromRoute] int accountId, [FromRoute] int lessonId)
    {
        GetByAccountIdAndLessonIdAccountLessonResponse response = await Mediator.Send(new GetByAccountIdAndLessonIdAccountLessonQuery {AccountId = accountId, LessonId = lessonId });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAccountLessonQuery getListAccountLessonQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAccountLessonListItemDto> response = await Mediator.Send(getListAccountLessonQuery);
        return Ok(response);
    }
}