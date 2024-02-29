using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountLearningPaths.Queries.GetListByAccountId;
public class GetListByAccountIdAccountLearningPathListItemDto :IDto
{
    public int Id { get; set; }
    public int LearningPathId { get; set; }
    public int LearningPathCategoryId { get; set; }
    public string LearningPathName { get; set; }
    public bool Visibility { get; set; }
    public DateTime StartingTime { get; set; }
    public DateTime EndingTime { get; set; }
    public int NumberOfLikes { get; set; }
    public int TotalDuration { get; set; }
    public string ImageUrl { get; set; }
    public byte PercentComplete { get; set; }
    public int TotalNumberOfPoints { get; set; }
    public bool IsContinue { get; set; }
    public bool IsComplete { get; set; }
    public bool IsLiked { get; set; }
    public bool IsSaved { get; set; }
    public bool IsActive { get; set; }
}
