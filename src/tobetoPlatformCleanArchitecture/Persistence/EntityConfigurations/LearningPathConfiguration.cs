using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LearningPathConfiguration : IEntityTypeConfiguration<LearningPath>
{
    public void Configure(EntityTypeBuilder<LearningPath> builder)
    {
        builder.ToTable("LearningPaths").HasKey(lp => lp.Id);

        builder.Property(lp => lp.Id).HasColumnName("Id").IsRequired();
        builder.Property(lp => lp.LearningPathCategoryId).HasColumnName("LearningPathCategoryId");
        builder.Property(lp => lp.Name).HasColumnName("Name");
        builder.Property(lp => lp.Visibility).HasColumnName("Visibility");
        builder.Property(lp => lp.StartingTime).HasColumnName("StartingTime");
        builder.Property(lp => lp.EndingTime).HasColumnName("EndingTime");
        builder.Property(lp => lp.NumberOfLikes).HasColumnName("NumberOfLikes");
        builder.Property(lp => lp.TotalDuration).HasColumnName("TotalDuration");
        builder.Property(lp => lp.ImageUrl).HasColumnName("ImageUrl");
        builder.Property(lp => lp.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(lp => lp.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(lp => lp.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(lp => !lp.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }

    private HashSet<LearningPath> getSeeds()
    {
        int id = 0;
        HashSet<LearningPath> seeds =
            new()
            {
                    new LearningPath { Id = ++id, LearningPathCategoryId=1,Name=".NET & React Full-Stack | Öğrenme Yolculuğu", Visibility=true, StartingTime= new DateTime(2024, 2, 20).AddHours(16).AddMinutes(45), EndingTime= new DateTime(2024, 4, 15).AddHours(18).AddMinutes(00), NumberOfLikes=11, TotalDuration=30, ImageUrl="/assets/images/dotnet-react-full-stack.png"},

                    new LearningPath { Id = ++id, LearningPathCategoryId=1,Name="İstanbul Kodluyor Proje Aşamaları", Visibility=true, StartingTime= new DateTime(2024, 1, 20).AddHours(12).AddMinutes(30), EndingTime= new DateTime(2024, 1, 20).AddHours(17).AddMinutes(00), NumberOfLikes=42, TotalDuration=1, ImageUrl="https://lms.tobeto.com/tobeto/eep/common_show_picture_cached.aspx?pQS=eaAjNZ0uaOHiut7Ip2g6BA%3d%3d"}, 

                    new LearningPath { Id = ++id, LearningPathCategoryId=1,Name="Java & Angular Full-Stack | Öğrenme Yolculuğu", Visibility=true, StartingTime= new DateTime(2023, 11, 10).AddHours(11).AddMinutes(00), EndingTime= new DateTime(2024, 2, 24).AddHours(23).AddMinutes(59), NumberOfLikes=33, TotalDuration=1027 , ImageUrl="https://i.ytimg.com/vi/ddqiBbmA6r8/maxresdefault.jpg"}, 

                    new LearningPath { Id = ++id, LearningPathCategoryId=1,Name="Flutter Mobil Programlama | Öğrenme Yolculuğu", Visibility=true, StartingTime= new DateTime(2023, 12, 30).AddHours(16).AddMinutes(45), EndingTime= new DateTime(2024, 1, 22).AddHours(17).AddMinutes(00), NumberOfLikes=22, TotalDuration=1120, ImageUrl="https://uploads-ssl.webflow.com/5f841209f4e71b2d70034471/60bb4a2e143f632da3e56aea_Flutter%20app%20development%20(2).png"}, 

                    new LearningPath { Id = ++id, LearningPathCategoryId=1,Name="Mülakatlarda Öne Geçme Teknikleri | Softskill", Visibility=true, StartingTime= new DateTime(2024, 1, 11).AddHours(11).AddMinutes(00), EndingTime= new DateTime(2024, 1, 28).AddHours(23).AddMinutes(59), NumberOfLikes=15, TotalDuration=60, ImageUrl="https://lh3.googleusercontent.com/proxy/H4zl7fiYhYBhymjzsYWqfrfmEnOuHf5zbDi_ccmg7hfQsssASfLZAGit_S2tz8XqtFeNHVOw2uRznzHMaag98EH2EbjQiuBusYJ7n7YSEpEBqr4uCAfO5y05P_6m7gSrMsxvvvnj-I2oMkNByBStqW01fzB1ag"}, 
            };
        return seeds;
    }
}