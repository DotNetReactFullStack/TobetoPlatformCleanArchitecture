using Core.Application.Responses;

namespace Application.Features.Lessons.Commands.Delete;

public class DeletedLessonResponse : IResponse
{
    public int Id { get; set; }
}