using Core.Application.Responses;

namespace Application.Features.AccountRecourses.Queries.GetById;

public class GetByIdAccountRecourseResponse : IResponse
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int ApplicationId { get; set; }
    public int ApplicationStepId { get; set; }
}