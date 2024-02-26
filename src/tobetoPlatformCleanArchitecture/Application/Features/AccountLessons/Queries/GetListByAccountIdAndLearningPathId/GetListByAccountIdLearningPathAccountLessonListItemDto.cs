using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountLessons.Queries.GetListByAccountIdAndLearningPathId;
public class GetListByAccountIdLearningPathAccountLessonListItemDto : IDto
{
    public int LearningPathId { get; set; }
    public int CourseId { get; set; }
    public int LessonId { get; set; }
    public int AccountId { get; set; }
    public int Points { get; set; }
    public bool IsComplete { get; set; }
    public int LessonDuration { get; set; }
}
