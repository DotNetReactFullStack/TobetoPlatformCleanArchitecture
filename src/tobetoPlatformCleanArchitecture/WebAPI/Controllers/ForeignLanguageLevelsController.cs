using Application.Features.ForeignLanguageLevels.Commands.Create;
using Application.Features.ForeignLanguageLevels.Commands.Delete;
using Application.Features.ForeignLanguageLevels.Commands.Update;
using Application.Features.ForeignLanguageLevels.Queries.GetById;
using Application.Features.ForeignLanguageLevels.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ForeignLanguageLevelsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateForeignLanguageLevelCommand createForeignLanguageLevelCommand)
    {
        CreatedForeignLanguageLevelResponse response = await Mediator.Send(createForeignLanguageLevelCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateForeignLanguageLevelCommand updateForeignLanguageLevelCommand)
    {
        UpdatedForeignLanguageLevelResponse response = await Mediator.Send(updateForeignLanguageLevelCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedForeignLanguageLevelResponse response = await Mediator.Send(new DeleteForeignLanguageLevelCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdForeignLanguageLevelResponse response = await Mediator.Send(new GetByIdForeignLanguageLevelQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListForeignLanguageLevelQuery getListForeignLanguageLevelQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListForeignLanguageLevelListItemDto> response = await Mediator.Send(getListForeignLanguageLevelQuery);
        return Ok(response);
    }
}