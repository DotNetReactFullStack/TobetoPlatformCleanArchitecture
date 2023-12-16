using Core.Application.Responses;

namespace Application.Features.Answers.Commands.Delete;

public class DeletedAnswerResponse : IResponse
{
    public int Id { get; set; }
}