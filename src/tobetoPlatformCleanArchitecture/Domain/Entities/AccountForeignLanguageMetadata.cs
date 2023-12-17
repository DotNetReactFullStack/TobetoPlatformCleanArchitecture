using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class AccountForeignLanguageMetadata : Entity<int>
{
    public int AccountId { get; set; }
    public int ForeignLanguageId { get; set; }
    public int ForeignLanguageLevelId { get; set; }
    public int Priority { get; set; }

    public virtual Account? Account { get; set; }
    public virtual ForeignLanguage? ForeignLanguage { get; set; }
    public virtual ForeignLanguageLevel? ForeignLanguageLevel { get; set; }

    public AccountForeignLanguageMetadata()
    {
        
    }

    public AccountForeignLanguageMetadata(int id, int accountId, int foreignLanguageId, int foreignLanguageLevelId, int priority) : this()
    {
        Id = id;
        AccountId = accountId;
        ForeignLanguageId = foreignLanguageId;
        ForeignLanguageLevelId = foreignLanguageLevelId;
        Priority = priority;
    }
}
