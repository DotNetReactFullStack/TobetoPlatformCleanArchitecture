using Core.Application.Dtos;

namespace Application.Features.Exams.Queries.GetList;

public class GetListExamListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
    public string Description { get; set; }
    public byte NumberOfQuestions { get; set; }
    public DateTime StartingTime { get; set; }
    public DateTime EndingTime { get; set; }
    public bool IsActive { get; set; }
    public short Duration { get; set; }
}