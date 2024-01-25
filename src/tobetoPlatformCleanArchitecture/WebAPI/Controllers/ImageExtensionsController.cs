using Application.Features.ImageExtensions.Commands.Create;
using Application.Features.ImageExtensions.Commands.Delete;
using Application.Features.ImageExtensions.Commands.Update;
using Application.Features.ImageExtensions.Queries.GetById;
using Application.Features.ImageExtensions.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImageExtensionsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateImageExtensionCommand createImageExtensionCommand)
    {
        CreatedImageExtensionResponse response = await Mediator.Send(createImageExtensionCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateImageExtensionCommand updateImageExtensionCommand)
    {
        UpdatedImageExtensionResponse response = await Mediator.Send(updateImageExtensionCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedImageExtensionResponse response = await Mediator.Send(new DeleteImageExtensionCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdImageExtensionResponse response = await Mediator.Send(new GetByIdImageExtensionQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListImageExtensionQuery getListImageExtensionQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListImageExtensionListItemDto> response = await Mediator.Send(getListImageExtensionQuery);
        return Ok(response);
    }
}