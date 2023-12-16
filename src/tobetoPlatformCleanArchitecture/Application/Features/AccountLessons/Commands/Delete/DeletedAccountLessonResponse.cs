using Core.Application.Responses;

namespace Application.Features.AccountLessons.Commands.Delete;

public class DeletedAccountLessonResponse : IResponse
{
    public int Id { get; set; }
}