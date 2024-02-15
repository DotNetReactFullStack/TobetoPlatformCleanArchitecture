using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SocialMediaPlatformConfiguration : IEntityTypeConfiguration<SocialMediaPlatform>
{
    public void Configure(EntityTypeBuilder<SocialMediaPlatform> builder)
    {
        builder.ToTable("SocialMediaPlatforms").HasKey(smp => smp.Id);

        builder.Property(smp => smp.Id).HasColumnName("Id").IsRequired();
        builder.Property(smp => smp.Name).HasColumnName("Name");
        builder.Property(smp => smp.IconPath).HasColumnName("IconPath");
        builder.Property(smp => smp.Priority).HasColumnName("Priority");
        builder.Property(smp => smp.Visibility).HasColumnName("Visibility");
        builder.Property(smp => smp.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(smp => smp.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(smp => smp.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(smp => !smp.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }

    private HashSet<SocialMediaPlatform> getSeeds()
    {
        int id = 0;
        HashSet<SocialMediaPlatform> seeds =
            new()
            {
                new SocialMediaPlatform { Id = ++id, Name = "Github", IconPath="bi bi-github", Priority= 1, Visibility=true },
                new SocialMediaPlatform { Id = ++id, Name = "Linkedin", IconPath="bi bi-linkedin", Priority= 2, Visibility=true },
                new SocialMediaPlatform { Id = ++id, Name = "Instagram", IconPath="bi bi-instagram", Priority= 3, Visibility=true },
                new SocialMediaPlatform { Id = ++id, Name = "Twitter", IconPath="bi bi-twitter", Priority= 4, Visibility=true },
            };

        return seeds;
    }

}