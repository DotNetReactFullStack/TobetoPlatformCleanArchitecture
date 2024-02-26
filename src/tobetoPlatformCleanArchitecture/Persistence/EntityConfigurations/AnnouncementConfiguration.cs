using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
{
    public void Configure(EntityTypeBuilder<Announcement> builder)
    {
        builder.ToTable("Announcements").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.AnnouncementTypeId).HasColumnName("AnnouncementTypeId");
        builder.Property(a => a.OrganizationId).HasColumnName("OrganizationId");
        builder.Property(a => a.Priority).HasColumnName("Priority");
        builder.Property(a => a.Visibility).HasColumnName("Visibility");
        builder.Property(a => a.Name).HasColumnName("Name");
        builder.Property(a => a.Content).HasColumnName("Content");
        builder.Property(a => a.PublishedDate).HasColumnName("PublishedDate");
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }

    private HashSet<Announcement> getSeeds()
    {
        int id = 0;
        HashSet<Announcement> seeds =
            new()
            {
                new Announcement { Id = ++id, AnnouncementTypeId=1, OrganizationId=1, Name = "20 Şubat Kampüs Buluşması Hk.", Content="Heyecanla beklenen Son Kampüs Buluşması için geri sayıma başladık. Seninle tanışmak için sabırsızlanıyoruz...", PublishedDate=new DateTime(2024, 2, 1), Priority= 1, Visibility=true },
                new Announcement { Id = ++id, AnnouncementTypeId=1, OrganizationId=1, Name = "Mindset Anketi", Content="Projemize akademik bakış açılarını da eklemek için aşağıdaki formu doldurmanı rica ederiz.", PublishedDate=new DateTime(2024, 1, 20), Priority= 1, Visibility=true },
                new Announcement { Id = ++id, AnnouncementTypeId=1, OrganizationId=1, Name = "Ocak Ayı Tercih Formu Bilgilendirmesi", Content="Tercih formunu bekleyen adaylarımızın discorddaki duyuruyu takip etmesini rica ederiz.", PublishedDate=new DateTime(2024, 1, 10), Priority= 1, Visibility=true },
                new Announcement { Id = ++id, AnnouncementTypeId=1, OrganizationId=1, Name = "11 Ocak Kampüs Buluşması", Content="Herkes için Kodlama eğitimini bitiren kişilerin katılabileceği kampüs buluşmamız 11 Ocak 2024 tarihindedir. Discorddan form paylaşılmıştır. Bu katılım formunu doldurmayan arkadaşların doldurması önemlidir..", PublishedDate=new DateTime(2023, 12, 20), Priority= 1, Visibility=true },
            };

        return seeds;
    }
}