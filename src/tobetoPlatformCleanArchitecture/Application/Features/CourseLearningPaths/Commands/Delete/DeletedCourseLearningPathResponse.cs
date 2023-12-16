using Core.Application.Responses;

namespace Application.Features.CourseLearningPaths.Commands.Delete;

public class DeletedCourseLearningPathResponse : IResponse
{
    public int Id { get; set; }
}