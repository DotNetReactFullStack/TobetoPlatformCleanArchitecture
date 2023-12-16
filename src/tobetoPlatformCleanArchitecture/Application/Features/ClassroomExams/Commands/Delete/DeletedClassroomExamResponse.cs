using Core.Application.Responses;

namespace Application.Features.ClassroomExams.Commands.Delete;

public class DeletedClassroomExamResponse : IResponse
{
    public int Id { get; set; }
}