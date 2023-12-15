using Application.Features.EducationPrograms.Commands.Create;
using Application.Features.EducationPrograms.Commands.Delete;
using Application.Features.EducationPrograms.Commands.Update;
using Application.Features.EducationPrograms.Queries.GetById;
using Application.Features.EducationPrograms.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EducationProgramsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateEducationProgramCommand createEducationProgramCommand)
    {
        CreatedEducationProgramResponse response = await Mediator.Send(createEducationProgramCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateEducationProgramCommand updateEducationProgramCommand)
    {
        UpdatedEducationProgramResponse response = await Mediator.Send(updateEducationProgramCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedEducationProgramResponse response = await Mediator.Send(new DeleteEducationProgramCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdEducationProgramResponse response = await Mediator.Send(new GetByIdEducationProgramQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListEducationProgramQuery getListEducationProgramQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListEducationProgramListItemDto> response = await Mediator.Send(getListEducationProgramQuery);
        return Ok(response);
    }
}