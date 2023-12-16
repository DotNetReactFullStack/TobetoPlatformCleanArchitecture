using Application.Features.Surveys.Commands.Create;
using Application.Features.Surveys.Commands.Delete;
using Application.Features.Surveys.Commands.Update;
using Application.Features.Surveys.Queries.GetById;
using Application.Features.Surveys.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SurveysController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSurveyCommand createSurveyCommand)
    {
        CreatedSurveyResponse response = await Mediator.Send(createSurveyCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSurveyCommand updateSurveyCommand)
    {
        UpdatedSurveyResponse response = await Mediator.Send(updateSurveyCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedSurveyResponse response = await Mediator.Send(new DeleteSurveyCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdSurveyResponse response = await Mediator.Send(new GetByIdSurveyQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSurveyQuery getListSurveyQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSurveyListItemDto> response = await Mediator.Send(getListSurveyQuery);
        return Ok(response);
    }
}