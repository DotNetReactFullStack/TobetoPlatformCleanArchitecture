using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Image : Entity<int>
{
    public int ImageExtensionId { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public bool IsActive { get; set; }

    public virtual ImageExtension ImageExtension { get; set; }

    public Image()
    {

    }

    public Image(int id, int imageExtensionId, string name, string url, bool isActive) : this()
    {
        Id = id;
        ImageExtensionId = imageExtensionId;
        Name = name;
        Url = url;
        IsActive = isActive;
    }
}

