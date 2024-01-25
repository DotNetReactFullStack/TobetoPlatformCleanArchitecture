using Application.Features.LearningPathCategories.Commands.Create;
using Application.Features.LearningPathCategories.Commands.Delete;
using Application.Features.LearningPathCategories.Commands.Update;
using Application.Features.LearningPathCategories.Queries.GetById;
using Application.Features.LearningPathCategories.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LearningPathCategoriesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateLearningPathCategoryCommand createLearningPathCategoryCommand)
    {
        CreatedLearningPathCategoryResponse response = await Mediator.Send(createLearningPathCategoryCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateLearningPathCategoryCommand updateLearningPathCategoryCommand)
    {
        UpdatedLearningPathCategoryResponse response = await Mediator.Send(updateLearningPathCategoryCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedLearningPathCategoryResponse response = await Mediator.Send(new DeleteLearningPathCategoryCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdLearningPathCategoryResponse response = await Mediator.Send(new GetByIdLearningPathCategoryQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLearningPathCategoryQuery getListLearningPathCategoryQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListLearningPathCategoryListItemDto> response = await Mediator.Send(getListLearningPathCategoryQuery);
        return Ok(response);
    }
}