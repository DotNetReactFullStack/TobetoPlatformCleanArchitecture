using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class AccountSocialMediaPlatform : Entity<int>
{
    public int AccountId { get; set; }
    public int SocialMediaPlatformId { get; set; }
    public int Priority { get; set; }
    public string Link { get; set; }

    public virtual Account? Account { get; set; }
    public virtual SocialMediaPlatform? SocialMediaPlatform { get; set; }

    public AccountSocialMediaPlatform()
    {
        
    }

    public AccountSocialMediaPlatform(int id, int accountId, int socialMediaPlatformId, int priority, string link) : this()
    {
        Id = id;
        AccountId = accountId;
        SocialMediaPlatformId = socialMediaPlatformId;
        Priority = priority;
        Link = link;
    }
}
