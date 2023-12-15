using Application.Features.ForeignLanguages.Commands.Create;
using Application.Features.ForeignLanguages.Commands.Delete;
using Application.Features.ForeignLanguages.Commands.Update;
using Application.Features.ForeignLanguages.Queries.GetById;
using Application.Features.ForeignLanguages.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ForeignLanguagesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateForeignLanguageCommand createForeignLanguageCommand)
    {
        CreatedForeignLanguageResponse response = await Mediator.Send(createForeignLanguageCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateForeignLanguageCommand updateForeignLanguageCommand)
    {
        UpdatedForeignLanguageResponse response = await Mediator.Send(updateForeignLanguageCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedForeignLanguageResponse response = await Mediator.Send(new DeleteForeignLanguageCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdForeignLanguageResponse response = await Mediator.Send(new GetByIdForeignLanguageQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListForeignLanguageQuery getListForeignLanguageQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListForeignLanguageListItemDto> response = await Mediator.Send(getListForeignLanguageQuery);
        return Ok(response);
    }
}