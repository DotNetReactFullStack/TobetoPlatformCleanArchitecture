using Core.Application.Responses;

namespace Application.Features.Exams.Commands.Delete;

public class DeletedExamResponse : IResponse
{
    public int Id { get; set; }
}