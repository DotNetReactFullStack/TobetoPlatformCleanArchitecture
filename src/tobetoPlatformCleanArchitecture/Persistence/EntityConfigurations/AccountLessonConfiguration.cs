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
    }
}