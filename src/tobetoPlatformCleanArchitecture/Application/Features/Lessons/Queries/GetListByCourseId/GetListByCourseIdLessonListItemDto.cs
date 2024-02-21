using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Lessons.Queries.GetListByCourseId;
public class GetListByCourseIdLessonListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Visibility { get; set; }
    public string Language { get; set; }
    public string Content { get; set; }
    public int Duration { get; set; }
    public bool IsActive { get; set; }
    public string VideoUrl { get; set; }
}
