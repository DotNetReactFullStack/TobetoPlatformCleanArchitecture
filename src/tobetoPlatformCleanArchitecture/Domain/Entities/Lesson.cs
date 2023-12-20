using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Lesson : Entity<int>
{
    public int CourseId { get; set; }
    public string Name { get; set; }
    public bool Visibility { get; set; }
    public string Language { get; set; }
    public string Content { get; set; }
    public int Duration { get; set; }
    public bool IsActive { get; set; }

    public virtual Course? Course { get; set; }
    public virtual ICollection<AccountLesson> AccountLessons { get; set; }

    public Lesson()
    {
        
    }

    public Lesson(int id, int courseId, string name, bool visibility, string language, string content, int duration, bool isActive) : this()
    {
        Id = id;
        CourseId = courseId;
        Name = name;
        Visibility = visibility;
        Language = language;
        Content = content;
        Duration = duration;
        IsActive = isActive;
    }
}
