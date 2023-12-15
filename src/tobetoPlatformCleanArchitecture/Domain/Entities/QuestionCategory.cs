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

    public QuestionCategory()
    {
        
    }

    public QuestionCategory(string name):this()
    {
        Name = name;
    }
}
