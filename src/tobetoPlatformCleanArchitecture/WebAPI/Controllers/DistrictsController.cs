using Application.Features.Cities.Queries.GetListByCountryId;
using Application.Features.Districts.Commands.Create;
using Application.Features.Districts.Commands.Delete;
using Application.Features.Districts.Commands.Update;
using Application.Features.Districts.Queries.GetById;
using Application.Features.Districts.Queries.GetList;
using Application.Features.Districts.Queries.GetListByCityId;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DistrictsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateDistrictCommand createDistrictCommand)
    {
        CreatedDistrictResponse response = await Mediator.Send(createDistrictCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateDistrictCommand updateDistrictCommand)
    {
        UpdatedDistrictResponse response = await Mediator.Send(updateDistrictCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedDistrictResponse response = await Mediator.Send(new DeleteDistrictCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdDistrictResponse response = await Mediator.Send(new GetByIdDistrictQuery { Id = id });
        return Ok(response);
    }

    [HttpGet("getByCityId/{cityId}")]
    public async Task<IActionResult> GetListByCountryId([FromRoute] int cityId, [FromQuery] PageRequest pageRequest)
    {
        GetListByCityIdDistrictQuery getListByCityIdDistrictQuery = new() { PageRequest = pageRequest, CityId = cityId };
        GetListResponse<GetListByCityIdDistrictListItemDto> response = await Mediator.Send(getListByCityIdDistrictQuery);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDistrictQuery getListDistrictQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListDistrictListItemDto> response = await Mediator.Send(getListDistrictQuery);
        return Ok(response);
    }
}