using Application.Features.Colleges.Commands.Create;
using Application.Features.Colleges.Commands.Delete;
using Application.Features.Colleges.Commands.Update;
using Application.Features.Colleges.Queries.GetById;
using Application.Features.Colleges.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CollegesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCollegeCommand createCollegeCommand)
    {
        CreatedCollegeResponse response = await Mediator.Send(createCollegeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCollegeCommand updateCollegeCommand)
    {
        UpdatedCollegeResponse response = await Mediator.Send(updateCollegeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCollegeResponse response = await Mediator.Send(new DeleteCollegeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCollegeResponse response = await Mediator.Send(new GetByIdCollegeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCollegeQuery getListCollegeQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCollegeListItemDto> response = await Mediator.Send(getListCollegeQuery);
        return Ok(response);
    }
}