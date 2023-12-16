using Application.Features.SurveyTypes.Commands.Create;
using Application.Features.SurveyTypes.Commands.Delete;
using Application.Features.SurveyTypes.Commands.Update;
using Application.Features.SurveyTypes.Queries.GetById;
using Application.Features.SurveyTypes.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SurveyTypesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSurveyTypeCommand createSurveyTypeCommand)
    {
        CreatedSurveyTypeResponse response = await Mediator.Send(createSurveyTypeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSurveyTypeCommand updateSurveyTypeCommand)
    {
        UpdatedSurveyTypeResponse response = await Mediator.Send(updateSurveyTypeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedSurveyTypeResponse response = await Mediator.Send(new DeleteSurveyTypeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdSurveyTypeResponse response = await Mediator.Send(new GetByIdSurveyTypeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSurveyTypeQuery getListSurveyTypeQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSurveyTypeListItemDto> response = await Mediator.Send(getListSurveyTypeQuery);
        return Ok(response);
    }
}