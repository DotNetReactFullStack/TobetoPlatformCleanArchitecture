using Core.Application.Responses;

namespace Application.Features.ClassroomExams.Queries.GetById;

public class GetByIdClassroomExamResponse : IResponse
{
    public int Id { get; set; }
    public int ClassroomId { get; set; }
    public int ExamId { get; set; }
    public bool IsActive { get; set; }
}