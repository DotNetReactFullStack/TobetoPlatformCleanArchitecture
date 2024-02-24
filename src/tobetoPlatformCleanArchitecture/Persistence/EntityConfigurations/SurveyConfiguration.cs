using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
{
    public void Configure(EntityTypeBuilder<Survey> builder)
    {
        builder.ToTable("Surveys").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.SurveyTypeId).HasColumnName("SurveyTypeId");
        builder.Property(s => s.OrganizationId).HasColumnName("OrganizationId");
        builder.Property(s => s.Priority).HasColumnName("Priority");
        builder.Property(s => s.Visibility).HasColumnName("Visibility");
        builder.Property(s => s.Title).HasColumnName("Title");
        builder.Property(s => s.Content).HasColumnName("Content");
        builder.Property(s => s.ConnectionLink).HasColumnName("ConnectionLink");
        builder.Property(s => s.IsActive).HasColumnName("IsActive");
        builder.Property(s => s.PublishedDate).HasColumnName("PublishedDate");
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }

    private HashSet<Survey> getSeeds()
    {
        int id = 0;
        HashSet<Survey> seeds =
            new()
            {
                new Survey { Id = ++id, SurveyTypeId=2, OrganizationId=1, Title = "Mindset Anketi", Content="Mindset anketi içeriği...", ConnectionLink="https://form.jotform.com/240143980661960", IsActive=true, PublishedDate=DateTime.Now, Priority= 1, Visibility=true },
            };

        return seeds;
    }
}