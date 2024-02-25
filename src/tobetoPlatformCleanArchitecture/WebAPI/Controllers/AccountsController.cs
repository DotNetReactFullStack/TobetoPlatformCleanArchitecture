using Application.Features.Accounts.Commands.Create;
using Application.Features.Accounts.Commands.Delete;
using Application.Features.Accounts.Commands.Update;
using Application.Features.Accounts.Commands.Update.UpdateAccountInformation;
using Application.Features.Accounts.Queries.GetById;
using Application.Features.Accounts.Queries.GetByUserId;
using Application.Features.Accounts.Queries.GetList;
using Application.Services.Accounts;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : BaseController
{
    IAccountsService _accountsService;

    public AccountsController(IAccountsService accountsService)
    {
        _accountsService = accountsService;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAccountCommand createAccountCommand)
    {
        CreatedAccountResponse response = await Mediator.Send(createAccountCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAccountCommand updateAccountCommand)
    {
        updateAccountCommand.UserIdForCheck = _accountsService.GetUserIdFromToken(HttpContext.Request.Headers["Authorization"]);

        UpdatedAccountResponse response = await Mediator.Send(updateAccountCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedAccountResponse response = await Mediator.Send(new DeleteAccountCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdAccountResponse response = await Mediator.Send(new GetByIdAccountQuery { Id = id });
        return Ok(response);
    }

    [HttpGet("getByUserId/{userId}")]
    public async Task<IActionResult> GetByUserId([FromRoute] int userId)
    {
        GetByUserIdAccountResponse response = await Mediator.Send(new GetByUserIdAccountQuery { UserId = userId });
        return Ok(response);
    }

    [HttpPut("updateAccountInformation")]
    public async Task<IActionResult> UpdateFront([FromBody] UpdateAccountInformationCommand updateAccountFrontCommand)
    {
        UpdatedAccountResponse response = await Mediator.Send(updateAccountFrontCommand);

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAccountQuery getListAccountQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAccountListItemDto> response = await Mediator.Send(getListAccountQuery);
        return Ok(response);
    }
}