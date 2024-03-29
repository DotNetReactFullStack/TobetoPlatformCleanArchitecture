﻿using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class LearningPath : Entity<int>
{
    public int LearningPathCategoryId { get; set; }
    public string Name { get; set; }    
    public bool Visibility { get; set; }
    public DateTime StartingTime { get; set; }
    public DateTime EndingTime { get; set; }
    public int NumberOfLikes { get; set; }
    public int TotalDuration { get; set; }
    public string ImageUrl { get; set; }

    public virtual LearningPathCategory LearningPathCategory { get; set; }
    public virtual ICollection<CourseLearningPath> CourseLearningPaths { get; set; }
    public virtual ICollection<AccountLearningPath> AccountLearningPaths { get; set; }
    

    public LearningPath()
    {

    }

    public LearningPath(int id, int learningPathCategoryId, string name, bool visibility, DateTime startingTime, DateTime endingTime, int numberOfLikes, int totalDuration) : this()
    {
        Id = id;
        LearningPathCategoryId = learningPathCategoryId;
        Name = name;
        Visibility = visibility;
        StartingTime = startingTime;
        EndingTime = endingTime;
        NumberOfLikes = numberOfLikes;
        TotalDuration = totalDuration;
    }
}

