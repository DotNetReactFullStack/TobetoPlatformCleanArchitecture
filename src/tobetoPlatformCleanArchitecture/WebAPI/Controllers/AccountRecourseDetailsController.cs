using Application.Features.AccountRecourseDetails.Commands.Create;
using Application.Features.AccountRecourseDetails.Commands.Delete;
using Application.Features.AccountRecourseDetails.Commands.Update;
using Application.Features.AccountRecourseDetails.Queries.GetById;
using Application.Features.AccountRecourseDetails.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountRecourseDetailsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAccountRecourseDetailCommand createAccountRecourseDetailCommand)
    {
        CreatedAccountRecourseDetailResponse response = await Mediator.Send(createAccountRecourseDetailCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAccountRecourseDetailCommand updateAccountRecourseDetailCommand)
    {
        UpdatedAccountRecourseDetailResponse response = await Mediator.Send(updateAccountRecourseDetailCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedAccountRecourseDetailResponse response = await Mediator.Send(new DeleteAccountRecourseDetailCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdAccountRecourseDetailResponse response = await Mediator.Send(new GetByIdAccountRecourseDetailQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAccountRecourseDetailQuery getListAccountRecourseDetailQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAccountRecourseDetailListItemDto> response = await Mediator.Send(getListAccountRecourseDetailQuery);
        return Ok(response);
    }
}