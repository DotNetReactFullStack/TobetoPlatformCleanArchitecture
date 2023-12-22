using Core.Application.Responses;

namespace Application.Features.AccountRecourses.Commands.Update;

public class UpdatedAccountRecourseResponse : IResponse
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int RecourseId { get; set; }
    public int RecourseStepId { get; set; }
}