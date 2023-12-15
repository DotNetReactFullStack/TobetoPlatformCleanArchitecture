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
    public string Language { get; set; }
    public string Content { get; set; }


    public Lesson()
    {
        
    }

    public Lesson(int courseId, string name, string language, string content) : this()
    {
        CourseId = courseId;
        Name = name;
        Language = language;
        Content = content;
    }
}
