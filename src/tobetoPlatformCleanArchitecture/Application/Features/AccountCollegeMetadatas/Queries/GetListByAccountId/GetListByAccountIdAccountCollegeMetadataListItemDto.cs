using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountCollegeMetadatas.Queries.GetListByAccountId;
public class GetListByAccountIdAccountCollegeMetadataListItemDto : IDto
{
    public int Id { get; set; }
    public string GraduationStatusName{ get; set; }
    public string CollegeName { get; set; }
    public string EducationProgramName { get; set; }
    public bool Visibility { get; set; }
    public DateTime StartingYear { get; set; }
    public DateTime? GraduationYear { get; set; }
    public bool ProgramOnGoing { get; set; }
}
