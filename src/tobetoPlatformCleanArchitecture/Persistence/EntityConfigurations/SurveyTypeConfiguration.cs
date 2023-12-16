using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SurveyTypeConfiguration : IEntityTypeConfiguration<SurveyType>
{
    public void Configure(EntityTypeBuilder<SurveyType> builder)
    {
        builder.ToTable("SurveyTypes").HasKey(st => st.Id);

        builder.Property(st => st.Id).HasColumnName("Id").IsRequired();
        builder.Property(st => st.Name).HasColumnName("Name");
        builder.Property(st => st.Priority).HasColumnName("Priority");
        builder.Property(st => st.Visibility).HasColumnName("Visibility");
        builder.Property(st => st.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(st => st.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(st => st.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(st => !st.DeletedDate.HasValue);
    }
}