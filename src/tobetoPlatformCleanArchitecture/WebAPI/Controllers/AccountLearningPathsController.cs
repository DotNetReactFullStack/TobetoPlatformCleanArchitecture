using Application.Features.AccountLearningPaths.Commands.Create;
using Application.Features.AccountLearningPaths.Commands.Delete;
using Application.Features.AccountLearningPaths.Commands.Update;
using Application.Features.AccountLearningPaths.Commands.Update.UpdateAccountLearningPathIsLiked;
using Application.Features.AccountLearningPaths.Commands.Update.UpdateAccountLearningPathIsSaved;
using Application.Features.AccountLearningPaths.Commands.Update.UpdateAccountLearningPathPercentComplete;
using Application.Features.AccountLearningPaths.Queries.GetById;
using Application.Features.AccountLearningPaths.Queries.GetList;
using Application.Features.AccountLearningPaths.Queries.GetListByAccountId;
using Application.Features.AccountLearningPaths.Queries.GetListByLearningPathId;
using Application.Features.Experiences.Queries.GetListByAccountId;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountLearningPathsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAccountLearningPathCommand createAccountLearningPathCommand)
    {
        CreatedAccountLearningPathResponse response = await Mediator.Send(createAccountLearningPathCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAccountLearningPathCommand updateAccountLearningPathCommand)
    {
        UpdatedAccountLearningPathResponse response = await Mediator.Send(updateAccountLearningPathCommand);

        return Ok(response);
    }
    [HttpPut("IsLiked")]
    public async Task<IActionResult> UpdateIsLiked([FromBody] UpdateAccountLearningPathIsLikedCommand updateAccountLearningPathIsLikedCommand)
    {
        UpdatedAccountLearningPathResponse response = await Mediator.Send(updateAccountLearningPathIsLikedCommand);

        return Ok(response);
    }
    [HttpPut("IsSaved")]
    public async Task<IActionResult> UpdateIsSaved([FromBody] UpdateAccountLearningPathIsSavedCommand updateAccountLearningPathIsSavedCommand)
    {
        UpdatedAccountLearningPathResponse response = await Mediator.Send(updateAccountLearningPathIsSavedCommand);

        return Ok(response);
    }

    [HttpPut("PercentComplete")]
    public async Task<IActionResult> UpdatePercentComplete([FromBody] UpdateAccountLearningPathPercentCompleteCommand updateAccountLearningPathPercentCompleteCommand)
    {
        UpdatedAccountLearningPathResponse response = await Mediator.Send(updateAccountLearningPathPercentCompleteCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedAccountLearningPathResponse response = await Mediator.Send(new DeleteAccountLearningPathCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdAccountLearningPathResponse response = await Mediator.Send(new GetByIdAccountLearningPathQuery { Id = id });
        return Ok(response);
    }

    [HttpGet("getByAccountId/{accountId}/LearningPathId/{learningPathId}")]
    public async Task<IActionResult> GetListByAccountIdAndLearningPathId([FromRoute] int accountId, [FromRoute] int learningPathId)
    {
        GetByAccountIdAndLearningPathIdAccountLearningPathResponse response = await Mediator.Send(new GetByAccountIdAndLearningPathIdAccountLearningPathQuery { AccountId = accountId, LearningPathId = learningPathId });
        return Ok(response);
    }

    [HttpGet("getListByAccountId/{accountId}")]
    public async Task<IActionResult> GetListByAccountId([FromRoute] int accountId, [FromQuery] PageRequest pageRequest)
    {
        GetListByAccountIdAccountLearningPathQuery getListByAccountIdAccountLearningPathQuery = new() { AccountId = accountId, PageRequest = pageRequest };
        GetListResponse<GetListByAccountIdAccountLearningPathListItemDto> response = await Mediator.Send(getListByAccountIdAccountLearningPathQuery);
        return Ok(response);
    }

    [HttpGet("getByLearningPathId/{learningPathId}")]
    public async Task<IActionResult> GetListByLearningPathId([FromRoute] int learningPathId, [FromQuery] PageRequest pageRequest)
    {
        GetListByLearningPathIdAccountLearningPathQuery getListByLearningPathIdAccountLearningPathQuery = new() { LearningPathId = learningPathId, PageRequest = pageRequest };
        GetListResponse<GetListByLearningPathIdAccountLearningPathListItemDto> response = await Mediator.Send(getListByLearningPathIdAccountLearningPathQuery);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAccountLearningPathQuery getListAccountLearningPathQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAccountLearningPathListItemDto> response = await Mediator.Send(getListAccountLearningPathQuery);
        return Ok(response);
    }
}