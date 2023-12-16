using Application.Features.CourseCategories.Commands.Create;
using Application.Features.CourseCategories.Commands.Delete;
using Application.Features.CourseCategories.Commands.Update;
using Application.Features.CourseCategories.Queries.GetById;
using Application.Features.CourseCategories.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseCategoriesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCourseCategoryCommand createCourseCategoryCommand)
    {
        CreatedCourseCategoryResponse response = await Mediator.Send(createCourseCategoryCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCourseCategoryCommand updateCourseCategoryCommand)
    {
        UpdatedCourseCategoryResponse response = await Mediator.Send(updateCourseCategoryCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCourseCategoryResponse response = await Mediator.Send(new DeleteCourseCategoryCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCourseCategoryResponse response = await Mediator.Send(new GetByIdCourseCategoryQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCourseCategoryQuery getListCourseCategoryQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCourseCategoryListItemDto> response = await Mediator.Send(getListCourseCategoryQuery);
        return Ok(response);
    }
}