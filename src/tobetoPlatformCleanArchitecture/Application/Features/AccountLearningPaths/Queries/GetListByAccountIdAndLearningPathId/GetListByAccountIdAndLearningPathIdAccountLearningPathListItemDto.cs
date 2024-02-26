using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountLearningPaths.Queries.GetListByAccountIdAndLearningPathId;
public class GetListByAccountIdAndLearningPathIdAccountLearningPathListItemDto : IDto
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int LearningPathId { get; set; }
    public List<int> CourseIds { get; set; }
    public int LessonId { get; set; }
    public int TotalNumberOfPoints { get; set; }
    public byte PercentComplete { get; set; }
    public bool IsContinue { get; set; }
    public bool IsComplete { get; set; }
    public bool IsLiked { get; set; }
    public bool IsSaved { get; set; }
    public bool IsActive { get; set; }
    public int CourseTotalDuration { get; set; }
    public int LessonDuration { get; set; }
    public int AccountLessonPoints { get; set; }
    public bool AccountLessonIsContinue { get; set; }
}
