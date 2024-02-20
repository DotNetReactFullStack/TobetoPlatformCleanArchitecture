using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LearningPathCategoryConfiguration : IEntityTypeConfiguration<LearningPathCategory>
{
    public void Configure(EntityTypeBuilder<LearningPathCategory> builder)
    {
        builder.ToTable("LearningPathCategories").HasKey(lpc => lpc.Id);

        builder.Property(lpc => lpc.Id).HasColumnName("Id").IsRequired();
        builder.Property(lpc => lpc.Name).HasColumnName("Name");
        builder.Property(lpc => lpc.IsActive).HasColumnName("IsActive");
        builder.Property(lpc => lpc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(lpc => lpc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(lpc => lpc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(lpc => !lpc.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }

    private HashSet<LearningPathCategory> getSeeds()
    {
        int id = 0;
        HashSet<LearningPathCategory> seeds =
            new()
            {
                    new LearningPathCategory { Id = ++id, Name= "Genel", IsActive= true,},
            };
        return seeds;
    }
}