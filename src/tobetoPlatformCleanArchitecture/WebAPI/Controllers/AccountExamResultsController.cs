using Application.Features.AccountExamResults.Commands.Create;
using Application.Features.AccountExamResults.Commands.Delete;
using Application.Features.AccountExamResults.Commands.Update;
using Application.Features.AccountExamResults.Queries.GetById;
using Application.Features.AccountExamResults.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountExamResultsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAccountExamResultCommand createAccountExamResultCommand)
    {
        CreatedAccountExamResultResponse response = await Mediator.Send(createAccountExamResultCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAccountExamResultCommand updateAccountExamResultCommand)
    {
        UpdatedAccountExamResultResponse response = await Mediator.Send(updateAccountExamResultCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedAccountExamResultResponse response = await Mediator.Send(new DeleteAccountExamResultCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdAccountExamResultResponse response = await Mediator.Send(new GetByIdAccountExamResultQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAccountExamResultQuery getListAccountExamResultQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAccountExamResultListItemDto> response = await Mediator.Send(getListAccountExamResultQuery);
        return Ok(response);
    }
}