using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class AccountCollageMetadata : Entity<int>
{
    public int AccountId { get; set; }
    public int GraduationStatusId { get; set; }
    public int CollegeId { get; set; }
    public int EducationProgramId { get; set; }
    public bool Visibility { get; set; }
    public DateTime StartingYear { get; set; }
    public DateTime GraduationYear { get; set; }
    public bool ProgramOnGoing { get; set; }


    public AccountCollageMetadata()
    {
        
    }

    public AccountCollageMetadata(int id, int accountId, int educationStatusId, int collegeId, int educationProgramId, bool visibility, DateTime startingYear, DateTime graduationYear, bool programOnGoing) : this()
    {
        Id = id;
        AccountId = accountId;
        GraduationStatusId = educationStatusId;
        CollegeId = collegeId;
        EducationProgramId = educationProgramId;
        Visibility = visibility;
        StartingYear = startingYear;
        GraduationYear = graduationYear;
        ProgramOnGoing = programOnGoing;
    }
}
