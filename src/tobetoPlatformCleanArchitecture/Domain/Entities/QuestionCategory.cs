using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class QuestionCategory : Entity<int>
{
    public string Name { get; set; }
    public int Priority { get; set; }

    public virtual ICollection<Question> Questions { get; set; }

    public QuestionCategory()
    {
        
    }

    public QuestionCategory(int id, string name, int priority) : this()
    {
        Id= id;
        Name = name;
        Priority = priority;
    }
}
