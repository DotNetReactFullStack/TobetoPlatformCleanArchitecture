using Application.Features.AccountLearningPaths.Commands.Create;
using Application.Features.AccountLearningPaths.Commands.Delete;
using Application.Features.AccountLearningPaths.Commands.Update;
using Application.Features.AccountLearningPaths.Queries.GetById;
using Application.Features.AccountLearningPaths.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAccountLearningPathQuery getListAccountLearningPathQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAccountLearningPathListItemDto> response = await Mediator.Send(getListAccountLearningPathQuery);
        return Ok(response);
    }
}