using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RecourseDetailConfiguration : IEntityTypeConfiguration<RecourseDetail>
{
    public void Configure(EntityTypeBuilder<RecourseDetail> builder)
    {
        builder.ToTable("RecourseDetails").HasKey(rd => rd.Id);

        builder.Property(rd => rd.Id).HasColumnName("Id").IsRequired();
        builder.Property(rd => rd.Name).HasColumnName("Name");
        builder.Property(rd => rd.Priority).HasColumnName("Priority");
        builder.Property(rd => rd.Visibility).HasColumnName("Visibility");
        builder.Property(rd => rd.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(rd => rd.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(rd => rd.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(rd => !rd.DeletedDate.HasValue);
    }
}