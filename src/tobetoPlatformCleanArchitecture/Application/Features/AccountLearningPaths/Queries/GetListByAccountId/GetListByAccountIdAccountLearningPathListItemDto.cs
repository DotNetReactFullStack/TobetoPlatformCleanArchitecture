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
    public string LearningPathName { get; set; }
    public DateTime StartingTime { get; set; }
    public string ImageUrl { get; set; }
    public int TotalNumberOfPoints { get; set; }
    public byte PercentComplete { get; set; }
    public bool IsContinue { get; set; }
    public bool IsComplete { get; set; }
    public bool IsLiked { get; set; }
    public bool IsSaved { get; set; }
    public bool IsActive { get; set; }
}
