using Application.Features.AccountCertificates.Commands.Create;
using Application.Features.AccountCertificates.Commands.Delete;
using Application.Features.AccountCertificates.Commands.Update;
using Application.Features.AccountCertificates.Queries.GetById;
using Application.Features.AccountCertificates.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountCertificatesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAccountCertificateCommand createAccountCertificateCommand)
    {
        CreatedAccountCertificateResponse response = await Mediator.Send(createAccountCertificateCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAccountCertificateCommand updateAccountCertificateCommand)
    {
        UpdatedAccountCertificateResponse response = await Mediator.Send(updateAccountCertificateCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedAccountCertificateResponse response = await Mediator.Send(new DeleteAccountCertificateCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdAccountCertificateResponse response = await Mediator.Send(new GetByIdAccountCertificateQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAccountCertificateQuery getListAccountCertificateQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAccountCertificateListItemDto> response = await Mediator.Send(getListAccountCertificateQuery);
        return Ok(response);
    }
}