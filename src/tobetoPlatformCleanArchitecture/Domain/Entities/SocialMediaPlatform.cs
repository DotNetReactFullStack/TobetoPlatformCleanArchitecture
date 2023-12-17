using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class SocialMediaPlatform : Entity<int>
{
    public string Name { get; set; }
    public string IconPath { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }

    public virtual ICollection<AccountSocialMediaPlatform> AccountSocialMediaPlatforms { get; set; }

    public SocialMediaPlatform()
    {
        
    }

    public SocialMediaPlatform(int id, string name, string iconPath, int priority, bool visibility) : this()
    {
        Id = id;
        Name = name;
        IconPath = iconPath;
        Priority = priority;
        Visibility = visibility;
    }
}
