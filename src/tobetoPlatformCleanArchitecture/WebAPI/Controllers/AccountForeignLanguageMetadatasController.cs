using Application.Features.AccountForeignLanguageMetadatas.Commands.Create;
using Application.Features.AccountForeignLanguageMetadatas.Commands.Delete;
using Application.Features.AccountForeignLanguageMetadatas.Commands.Update;
using Application.Features.AccountForeignLanguageMetadatas.Queries.GetById;
using Application.Features.AccountForeignLanguageMetadatas.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountForeignLanguageMetadatasController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAccountForeignLanguageMetadataCommand createAccountForeignLanguageMetadataCommand)
    {
        CreatedAccountForeignLanguageMetadataResponse response = await Mediator.Send(createAccountForeignLanguageMetadataCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAccountForeignLanguageMetadataCommand updateAccountForeignLanguageMetadataCommand)
    {
        UpdatedAccountForeignLanguageMetadataResponse response = await Mediator.Send(updateAccountForeignLanguageMetadataCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedAccountForeignLanguageMetadataResponse response = await Mediator.Send(new DeleteAccountForeignLanguageMetadataCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdAccountForeignLanguageMetadataResponse response = await Mediator.Send(new GetByIdAccountForeignLanguageMetadataQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAccountForeignLanguageMetadataQuery getListAccountForeignLanguageMetadataQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAccountForeignLanguageMetadataListItemDto> response = await Mediator.Send(getListAccountForeignLanguageMetadataQuery);
        return Ok(response);
    }
}