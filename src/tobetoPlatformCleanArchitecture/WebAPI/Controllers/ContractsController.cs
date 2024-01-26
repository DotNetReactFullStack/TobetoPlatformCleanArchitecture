using Application.Features.Contracts.Commands.Create;
using Application.Features.Contracts.Commands.Delete;
using Application.Features.Contracts.Commands.Update;
using Application.Features.Contracts.Queries.GetById;
using Application.Features.Contracts.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContractsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateContractCommand createContractCommand)
    {
        CreatedContractResponse response = await Mediator.Send(createContractCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateContractCommand updateContractCommand)
    {
        UpdatedContractResponse response = await Mediator.Send(updateContractCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedContractResponse response = await Mediator.Send(new DeleteContractCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdContractResponse response = await Mediator.Send(new GetByIdContractQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListContractQuery getListContractQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListContractListItemDto> response = await Mediator.Send(getListContractQuery);
        return Ok(response);
    }
}