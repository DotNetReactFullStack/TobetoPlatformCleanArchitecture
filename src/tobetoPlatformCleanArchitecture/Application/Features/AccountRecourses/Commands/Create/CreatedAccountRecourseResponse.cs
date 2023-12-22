using Core.Application.Responses;

namespace Application.Features.AccountRecourses.Commands.Create;

public class CreatedAccountRecourseResponse : IResponse
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int RecourseId { get; set; }
    public int RecourseStepId { get; set; }
}