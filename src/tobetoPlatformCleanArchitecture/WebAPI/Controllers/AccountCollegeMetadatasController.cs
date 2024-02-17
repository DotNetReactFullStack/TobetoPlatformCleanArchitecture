using Application.Features.AccountCollegeMetadatas.Commands.Create;
using Application.Features.AccountCollegeMetadatas.Commands.Delete;
using Application.Features.AccountCollegeMetadatas.Commands.Update;
using Application.Features.AccountCollegeMetadatas.Queries.GetById;
using Application.Features.AccountCollegeMetadatas.Queries.GetList;
using Application.Features.AccountCollegeMetadatas.Queries.GetListByAccountId;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountCollegeMetadatasController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAccountCollegeMetadataCommand createAccountCollegeMetadataCommand)
    {
        CreatedAccountCollegeMetadataResponse response = await Mediator.Send(createAccountCollegeMetadataCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAccountCollegeMetadataCommand updateAccountCollegeMetadataCommand)
    {
        UpdatedAccountCollegeMetadataResponse response = await Mediator.Send(updateAccountCollegeMetadataCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedAccountCollegeMetadataResponse response = await Mediator.Send(new DeleteAccountCollegeMetadataCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdAccountCollegeMetadataResponse response = await Mediator.Send(new GetByIdAccountCollegeMetadataQuery { Id = id });
        return Ok(response);
    }

    [HttpGet("getByAccountId/{accountId}")]
    public async Task<IActionResult> GetList([FromRoute] int accountId, [FromQuery] PageRequest pageRequest)
    {
        GetListByAccountIdAccountCollegeMetadataQuery getListByAccountIdAccountCollegeMetadataQuery = new() {AccountId = accountId, PageRequest = pageRequest };
        GetListResponse<GetListByAccountIdAccountCollegeMetadataListItemDto> response = await Mediator.Send(getListByAccountIdAccountCollegeMetadataQuery);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAccountCollegeMetadataQuery getListAccountCollegeMetadataQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAccountCollegeMetadataListItemDto> response = await Mediator.Send(getListAccountCollegeMetadataQuery);
        return Ok(response);
    }
}