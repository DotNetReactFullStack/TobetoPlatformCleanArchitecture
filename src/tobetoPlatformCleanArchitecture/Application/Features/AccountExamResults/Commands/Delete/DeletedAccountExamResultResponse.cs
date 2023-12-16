using Core.Application.Responses;

namespace Application.Features.AccountExamResults.Commands.Delete;

public class DeletedAccountExamResultResponse : IResponse
{
    public int Id { get; set; }
}