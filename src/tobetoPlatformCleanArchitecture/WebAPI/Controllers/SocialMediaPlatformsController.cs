using Application.Features.SocialMediaPlatforms.Commands.Create;
using Application.Features.SocialMediaPlatforms.Commands.Delete;
using Application.Features.SocialMediaPlatforms.Commands.Update;
using Application.Features.SocialMediaPlatforms.Queries.GetById;
using Application.Features.SocialMediaPlatforms.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SocialMediaPlatformsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSocialMediaPlatformCommand createSocialMediaPlatformCommand)
    {
        CreatedSocialMediaPlatformResponse response = await Mediator.Send(createSocialMediaPlatformCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSocialMediaPlatformCommand updateSocialMediaPlatformCommand)
    {
        UpdatedSocialMediaPlatformResponse response = await Mediator.Send(updateSocialMediaPlatformCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedSocialMediaPlatformResponse response = await Mediator.Send(new DeleteSocialMediaPlatformCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdSocialMediaPlatformResponse response = await Mediator.Send(new GetByIdSocialMediaPlatformQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSocialMediaPlatformQuery getListSocialMediaPlatformQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSocialMediaPlatformListItemDto> response = await Mediator.Send(getListSocialMediaPlatformQuery);
        return Ok(response);
    }
}