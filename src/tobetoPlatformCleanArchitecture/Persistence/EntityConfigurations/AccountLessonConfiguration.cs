using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AccountLessonConfiguration : IEntityTypeConfiguration<AccountLesson>
{
    public void Configure(EntityTypeBuilder<AccountLesson> builder)
    {
        builder.ToTable("AccountLessons").HasKey(al => al.Id);

        builder.Property(al => al.Id).HasColumnName("Id").IsRequired();
        builder.Property(al => al.LessonId).HasColumnName("LessonId");
        builder.Property(al => al.AccountId).HasColumnName("AccountId");
        builder.Property(al => al.Points).HasColumnName("Points");
        builder.Property(al => al.IsComplete).HasColumnName("IsComplete");
        builder.Property(al => al.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(al => al.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(al => al.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(al => !al.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }

    private HashSet<AccountLesson> getSeeds()
    {
        int id = 0;
        HashSet<AccountLesson> seeds =
            new()
            {
                    new AccountLesson { Id = ++id, AccountId=1, LessonId=1, Points=100, IsComplete=true,},
                    new AccountLesson { Id = ++id, AccountId=1, LessonId=2, Points=20, IsComplete=false,},
                    new AccountLesson { Id = ++id, AccountId=1, LessonId=3, Points=50, IsComplete=false,},
                    new AccountLesson { Id = ++id, AccountId=1, LessonId=4, Points=80, IsComplete=false,},
                    new AccountLesson { Id = ++id, AccountId=1, LessonId=5, Points=0, IsComplete=false,},


            };
        return seeds;
    }
}