using Application.Features.AccountContracts.Commands.Create;
using Application.Features.AccountContracts.Commands.Delete;
using Application.Features.AccountContracts.Commands.Update;
using Application.Features.AccountContracts.Queries.GetById;
using Application.Features.AccountContracts.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountContractsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAccountContractCommand createAccountContractCommand)
    {
        CreatedAccountContractResponse response = await Mediator.Send(createAccountContractCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAccountContractCommand updateAccountContractCommand)
    {
        UpdatedAccountContractResponse response = await Mediator.Send(updateAccountContractCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedAccountContractResponse response = await Mediator.Send(new DeleteAccountContractCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdAccountContractResponse response = await Mediator.Send(new GetByIdAccountContractQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAccountContractQuery getListAccountContractQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAccountContractListItemDto> response = await Mediator.Send(getListAccountContractQuery);
        return Ok(response);
    }
}