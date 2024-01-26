using Application.Features.ContractTypes.Commands.Create;
using Application.Features.ContractTypes.Commands.Delete;
using Application.Features.ContractTypes.Commands.Update;
using Application.Features.ContractTypes.Queries.GetById;
using Application.Features.ContractTypes.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContractTypesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateContractTypeCommand createContractTypeCommand)
    {
        CreatedContractTypeResponse response = await Mediator.Send(createContractTypeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateContractTypeCommand updateContractTypeCommand)
    {
        UpdatedContractTypeResponse response = await Mediator.Send(updateContractTypeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedContractTypeResponse response = await Mediator.Send(new DeleteContractTypeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdContractTypeResponse response = await Mediator.Send(new GetByIdContractTypeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListContractTypeQuery getListContractTypeQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListContractTypeListItemDto> response = await Mediator.Send(getListContractTypeQuery);
        return Ok(response);
    }
}