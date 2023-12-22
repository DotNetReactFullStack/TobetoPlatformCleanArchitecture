using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class AccountAnnouncement : Entity<int>
{
    public int AccountId { get; set; }
    public int AnnouncementId { get; set; }
    public bool Read { get; set; }

    public virtual Account? Account { get; set; }
    public virtual Announcement? Announcement { get; set; }
    public AccountAnnouncement()
    {
            
    }

    public AccountAnnouncement(int id, int accountId, int announcementId, bool read) : this()
    {
        Id = id;
        AccountId = accountId;
        AnnouncementId = announcementId;
        Read = read;
    }
}
