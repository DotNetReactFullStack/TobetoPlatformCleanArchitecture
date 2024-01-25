using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Experience : Entity<int>
{
    public int AccountId { get; set; }
    public int CityId { get; set; }
    public string CompanyName { get; set; }
    public string JobTitle { get; set; }
    public string Industry { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime? EndingDate { get; set; }
    public bool IsCurrentlyWorking { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }


    public virtual Account Account { get; set; }
    public virtual City City { get; set; }

    public Experience()
    {
        
    }

    public Experience(int id, int accountId, int cityId, string companyName, string jobTitle, string ındustry, DateTime startingDate, DateTime? endingDate, bool ısCurrentlyWorking, string? description, bool ısActive) :this() 
    {
        Id = id;
        AccountId = accountId;
        CityId = cityId;
        CompanyName = companyName;
        JobTitle = jobTitle;
        Industry = ındustry;
        StartingDate = startingDate;
        EndingDate = endingDate;
        IsCurrentlyWorking = ısCurrentlyWorking;
        Description = description;
        IsActive = ısActive;
    }
}
