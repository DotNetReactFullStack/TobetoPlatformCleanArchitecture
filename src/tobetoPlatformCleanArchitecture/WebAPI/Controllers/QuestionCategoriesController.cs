using Application.Features.QuestionCategories.Commands.Create;
using Application.Features.QuestionCategories.Commands.Delete;
using Application.Features.QuestionCategories.Commands.Update;
using Application.Features.QuestionCategories.Queries.GetById;
using Application.Features.QuestionCategories.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionCategoriesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateQuestionCategoryCommand createQuestionCategoryCommand)
    {
        CreatedQuestionCategoryResponse response = await Mediator.Send(createQuestionCategoryCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateQuestionCategoryCommand updateQuestionCategoryCommand)
    {
        UpdatedQuestionCategoryResponse response = await Mediator.Send(updateQuestionCategoryCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedQuestionCategoryResponse response = await Mediator.Send(new DeleteQuestionCategoryCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdQuestionCategoryResponse response = await Mediator.Send(new GetByIdQuestionCategoryQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListQuestionCategoryQuery getListQuestionCategoryQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListQuestionCategoryListItemDto> response = await Mediator.Send(getListQuestionCategoryQuery);
        return Ok(response);
    }
}