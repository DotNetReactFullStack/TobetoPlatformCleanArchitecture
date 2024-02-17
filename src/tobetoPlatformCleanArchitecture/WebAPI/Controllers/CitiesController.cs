using Application.Features.Cities.Commands.Create;
using Application.Features.Cities.Commands.Delete;
using Application.Features.Cities.Commands.Update;
using Application.Features.Cities.Queries.GetById;
using Application.Features.Cities.Queries.GetList;
using Application.Features.Cities.Queries.GetListByCountryId;
using Application.Features.EducationPrograms.Queries.GetListByCollegeId;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CitiesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCityCommand createCityCommand)
    {
        CreatedCityResponse response = await Mediator.Send(createCityCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCityCommand updateCityCommand)
    {
        UpdatedCityResponse response = await Mediator.Send(updateCityCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCityResponse response = await Mediator.Send(new DeleteCityCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCityResponse response = await Mediator.Send(new GetByIdCityQuery { Id = id });
        return Ok(response);
    }

    [HttpGet("getByCountryId/{countryId}")]
    public async Task<IActionResult> GetListByCountryId([FromRoute] int countryId, [FromQuery] PageRequest pageRequest )
    {
        GetListByCountryIdCityQuery getListByCountryIdCityQuery = new() { PageRequest = pageRequest, CountryId = countryId };
        GetListResponse<GetListByCountryIdCityListItemDto> response = await Mediator.Send(getListByCountryIdCityQuery);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCityQuery getListCityQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCityListItemDto> response = await Mediator.Send(getListCityQuery);
        return Ok(response);
    }
}