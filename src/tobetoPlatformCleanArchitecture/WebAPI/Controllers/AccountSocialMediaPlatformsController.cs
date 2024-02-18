using Application.Features.AccountSocialMediaPlatforms.Commands.Create;
using Application.Features.AccountSocialMediaPlatforms.Commands.Delete;
using Application.Features.AccountSocialMediaPlatforms.Commands.Update;
using Application.Features.AccountSocialMediaPlatforms.Queries.GetById;
using Application.Features.AccountSocialMediaPlatforms.Queries.GetList;
using Application.Features.AccountSocialMediaPlatforms.Queries.GetListByAccountId;
using Application.Features.Cities.Queries.GetListByCountryId;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountSocialMediaPlatformsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAccountSocialMediaPlatformCommand createAccountSocialMediaPlatformCommand)
    {
        CreatedAccountSocialMediaPlatformResponse response = await Mediator.Send(createAccountSocialMediaPlatformCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAccountSocialMediaPlatformCommand updateAccountSocialMediaPlatformCommand)
    {
        UpdatedAccountSocialMediaPlatformResponse response = await Mediator.Send(updateAccountSocialMediaPlatformCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedAccountSocialMediaPlatformResponse response = await Mediator.Send(new DeleteAccountSocialMediaPlatformCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdAccountSocialMediaPlatformResponse response = await Mediator.Send(new GetByIdAccountSocialMediaPlatformQuery { Id = id });
        return Ok(response);
    }

    [HttpGet("getByAccountId/{accountId}")]
    public async Task<IActionResult> GetListByAccountId([FromRoute] int accountId, [FromQuery] PageRequest pageRequest)
    {
        GetListByAccountIdAccountSocialMediaPlatformsQuery getListByAccountIdAccountSocialMediaPlatformsQuery = new() { PageRequest = pageRequest, AccountId = accountId };
        GetListResponse<GetListByAccountIdAccountSocialMediaPlatformsItemDto> response = await Mediator.Send(getListByAccountIdAccountSocialMediaPlatformsQuery);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAccountSocialMediaPlatformQuery getListAccountSocialMediaPlatformQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAccountSocialMediaPlatformListItemDto> response = await Mediator.Send(getListAccountSocialMediaPlatformQuery);
        return Ok(response);
    }
}