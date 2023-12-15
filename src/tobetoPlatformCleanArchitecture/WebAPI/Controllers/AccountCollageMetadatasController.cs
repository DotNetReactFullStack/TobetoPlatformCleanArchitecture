using Application.Features.AccountCollageMetadatas.Commands.Create;
using Application.Features.AccountCollageMetadatas.Commands.Delete;
using Application.Features.AccountCollageMetadatas.Commands.Update;
using Application.Features.AccountCollageMetadatas.Queries.GetById;
using Application.Features.AccountCollageMetadatas.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountCollageMetadatasController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAccountCollageMetadataCommand createAccountCollageMetadataCommand)
    {
        CreatedAccountCollageMetadataResponse response = await Mediator.Send(createAccountCollageMetadataCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAccountCollageMetadataCommand updateAccountCollageMetadataCommand)
    {
        UpdatedAccountCollageMetadataResponse response = await Mediator.Send(updateAccountCollageMetadataCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedAccountCollageMetadataResponse response = await Mediator.Send(new DeleteAccountCollageMetadataCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdAccountCollageMetadataResponse response = await Mediator.Send(new GetByIdAccountCollageMetadataQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAccountCollageMetadataQuery getListAccountCollageMetadataQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAccountCollageMetadataListItemDto> response = await Mediator.Send(getListAccountCollageMetadataQuery);
        return Ok(response);
    }
}