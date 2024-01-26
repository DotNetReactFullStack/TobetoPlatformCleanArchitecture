using Application.Features.Experiences.Commands.Create;
using Application.Features.Experiences.Commands.Delete;
using Application.Features.Experiences.Commands.Update;
using Application.Features.Experiences.Queries.GetById;
using Application.Features.Experiences.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExperiencesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateExperienceCommand createExperienceCommand)
    {
        CreatedExperienceResponse response = await Mediator.Send(createExperienceCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateExperienceCommand updateExperienceCommand)
    {
        UpdatedExperienceResponse response = await Mediator.Send(updateExperienceCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedExperienceResponse response = await Mediator.Send(new DeleteExperienceCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdExperienceResponse response = await Mediator.Send(new GetByIdExperienceQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListExperienceQuery getListExperienceQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListExperienceListItemDto> response = await Mediator.Send(getListExperienceQuery);
        return Ok(response);
    }
}