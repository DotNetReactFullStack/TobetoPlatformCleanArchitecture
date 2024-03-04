using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AccountAnnouncementConfiguration : IEntityTypeConfiguration<AccountAnnouncement>
{
    public void Configure(EntityTypeBuilder<AccountAnnouncement> builder)
    {
        builder.ToTable("AccountAnnouncements").HasKey(aa => aa.Id);

        builder.Property(aa => aa.Id).HasColumnName("Id").IsRequired();
        builder.Property(aa => aa.AccountId).HasColumnName("AccountId");
        builder.Property(aa => aa.AnnouncementId).HasColumnName("AnnouncementId");
        builder.Property(aa => aa.Read).HasColumnName("Read");
        builder.Property(aa => aa.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(aa => aa.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(aa => aa.DeletedDate).HasColumnName("DeletedDate");

        builder
            .HasOne(a => a.Announcement)
            .WithMany(a => a.AccountAnnouncements)
            .HasForeignKey(a => a.AnnouncementId)
            .OnDelete(DeleteBehavior.ClientNoAction);

        builder.HasQueryFilter(aa => !aa.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }

    private HashSet<AccountAnnouncement> getSeeds()
    {
        int id = 0;
        HashSet<AccountAnnouncement> seeds =
            new()
            {
                new AccountAnnouncement { Id = ++id, AccountId=1, AnnouncementId = 1, Read=false },
                new AccountAnnouncement { Id = ++id, AccountId=1, AnnouncementId = 2, Read=false },
                new AccountAnnouncement { Id = ++id, AccountId=1, AnnouncementId = 3, Read=false },
                new AccountAnnouncement { Id = ++id, AccountId=1, AnnouncementId = 4, Read=false },
            };

        return seeds;
    }
}