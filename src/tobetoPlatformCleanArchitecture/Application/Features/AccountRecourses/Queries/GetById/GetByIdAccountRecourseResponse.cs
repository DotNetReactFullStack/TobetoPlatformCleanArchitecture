using Core.Application.Responses;

namespace Application.Features.AccountRecourses.Queries.GetById;

public class GetByIdAccountRecourseResponse : IResponse
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int RecourseId { get; set; }
    public int RecourseStepId { get; set; }
}