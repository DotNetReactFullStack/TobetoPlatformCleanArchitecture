using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CourseLearningPaths.Queries.GetListByLearningPathId;
public class GetListByLearningPathIdCourseLearningPathListItemDto :IDto
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int LearningPathId { get; set; }
    public int CourseCategoryId { get; set; }
    public string CourseName { get; set; }
    public int TotalDuration { get; set; }
    public int Priority { get; set; }
    public bool IsActive { get; set; }
    public bool Visibility { get; set; }
}
