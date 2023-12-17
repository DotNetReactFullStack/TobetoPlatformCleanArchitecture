using Core.Application.Responses;

namespace Application.Features.AccountRecourses.Commands.Update;

public class UpdatedAccountRecourseResponse : IResponse
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int ApplicationId { get; set; }
    public int ApplicationStepId { get; set; }
}