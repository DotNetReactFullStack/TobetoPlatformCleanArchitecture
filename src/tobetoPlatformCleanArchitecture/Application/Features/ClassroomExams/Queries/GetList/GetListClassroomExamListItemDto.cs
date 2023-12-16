using Core.Application.Dtos;

namespace Application.Features.ClassroomExams.Queries.GetList;

public class GetListClassroomExamListItemDto : IDto
{
    public int Id { get; set; }
    public int ClassroomId { get; set; }
    public int ExamId { get; set; }
    public bool IsActive { get; set; }
}