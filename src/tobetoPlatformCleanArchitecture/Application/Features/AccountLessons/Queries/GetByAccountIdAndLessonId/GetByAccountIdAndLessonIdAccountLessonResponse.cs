using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountLessons.Queries.GetListByAccountIdAndLessonId;
public class GetByAccountIdAndLessonIdAccountLessonResponse : IDto
{    
    public int Id { get; set; }
    public int LessonId { get; set; }
    public int AccountId { get; set; }
    public int Points { get; set; }
    public bool IsComplete { get; set; }
}
