using Core.Application.Responses;

namespace Application.Features.ClassroomExams.Commands.Create;

public class CreatedClassroomExamResponse : IResponse
{
    public int Id { get; set; }
    public int ClassroomId { get; set; }
    public int ExamId { get; set; }
    public bool IsActive { get; set; }
}