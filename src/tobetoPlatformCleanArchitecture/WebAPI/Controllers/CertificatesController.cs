using Application.Features.Certificates.Commands.Create;
using Application.Features.Certificates.Commands.Delete;
using Application.Features.Certificates.Commands.Update;
using Application.Features.Certificates.Queries.GetById;
using Application.Features.Certificates.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CertificatesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCertificateCommand createCertificateCommand)
    {
        CreatedCertificateResponse response = await Mediator.Send(createCertificateCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCertificateCommand updateCertificateCommand)
    {
        UpdatedCertificateResponse response = await Mediator.Send(updateCertificateCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCertificateResponse response = await Mediator.Send(new DeleteCertificateCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCertificateResponse response = await Mediator.Send(new GetByIdCertificateQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCertificateQuery getListCertificateQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCertificateListItemDto> response = await Mediator.Send(getListCertificateQuery);
        return Ok(response);
    }
}