using Application.Features.AccountCapabilities.Commands.Create;
using Application.Features.AccountCapabilities.Commands.Delete;
using Application.Features.AccountCapabilities.Commands.Update;
using Application.Features.AccountCapabilities.Queries.GetById;
using Application.Features.AccountCapabilities.Queries.GetList;
using Application.Features.AccountCapabilities.Queries.GetListByAccountId;
using Application.Features.Accounts.Queries.GetByUserId;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountCapabilitiesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAccountCapabilityCommand createAccountCapabilityCommand)
    {
        CreatedAccountCapabilityResponse response = await Mediator.Send(createAccountCapabilityCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAccountCapabilityCommand updateAccountCapabilityCommand)
    {
        UpdatedAccountCapabilityResponse response = await Mediator.Send(updateAccountCapabilityCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedAccountCapabilityResponse response = await Mediator.Send(new DeleteAccountCapabilityCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdAccountCapabilityResponse response = await Mediator.Send(new GetByIdAccountCapabilityQuery { Id = id });
        return Ok(response);
    }

    [HttpGet("getByAccountId/{accountId}")]
    public async Task<IActionResult> GetByAccountId([FromRoute] int accountId, [FromQuery] PageRequest pageRequest)
    {
        GetListByAccountIdAccountCapabilityQuery getListByAccountIdAccountCapabilityQuery = new() { AccountId=accountId, PageRequest = pageRequest };
        GetListResponse<GetListByAccountIdAccountCapabilityListItemDto> response = await Mediator.Send(getListByAccountIdAccountCapabilityQuery);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAccountCapabilityQuery getListAccountCapabilityQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAccountCapabilityListItemDto> response = await Mediator.Send(getListAccountCapabilityQuery);
        return Ok(response);
    }
}