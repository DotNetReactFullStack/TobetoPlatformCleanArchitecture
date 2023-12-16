using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ClassroomExamConfiguration : IEntityTypeConfiguration<ClassroomExam>
{
    public void Configure(EntityTypeBuilder<ClassroomExam> builder)
    {
        builder.ToTable("ClassroomExams").HasKey(ce => ce.Id);

        builder.Property(ce => ce.Id).HasColumnName("Id").IsRequired();
        builder.Property(ce => ce.ClassroomId).HasColumnName("ClassroomId");
        builder.Property(ce => ce.ExamId).HasColumnName("ExamId");
        builder.Property(ce => ce.IsActive).HasColumnName("IsActive");
        builder.Property(ce => ce.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ce => ce.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ce => ce.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ce => !ce.DeletedDate.HasValue);
    }
}