using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CapabilityConfiguration : IEntityTypeConfiguration<Capability>
{
    public void Configure(EntityTypeBuilder<Capability> builder)
    {
        builder.ToTable("Capabilities").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Name");
        builder.Property(c => c.Priority).HasColumnName("Priority");
        builder.Property(c => c.Visibility).HasColumnName("Visibility");
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }

    private HashSet<Capability> getSeeds()
    {
        int id = 0;
        HashSet<Capability> seeds =
            new()
            {
                new Capability { Id = ++id, Name = "SOLID", Priority= 1, Visibility=true },
                new Capability { Id = ++id, Name = "AOP", Priority= 1, Visibility=true },
                new Capability { Id = ++id, Name = "OOP", Priority= 1, Visibility=true },
                new Capability { Id = ++id, Name = "TypeScript", Priority= 1, Visibility=true },
                new Capability { Id = ++id, Name = "JavaScript", Priority= 1, Visibility=true },
                new Capability { Id = ++id, Name = "Vue.js", Priority= 1, Visibility=true },
                new Capability { Id = ++id, Name = "React", Priority= 1, Visibility=true },
                new Capability { Id = ++id, Name = "Angular", Priority= 1, Visibility=true },
                new Capability { Id = ++id, Name = "Vue", Priority= 1, Visibility=true },
                new Capability { Id = ++id, Name = ".NET", Priority= 1, Visibility=true },
                new Capability { Id = ++id, Name = "C#", Priority= 1, Visibility=true },
                new Capability { Id = ++id, Name = "Spring Boot", Priority= 1, Visibility=true },
                new Capability { Id = ++id, Name = "Java", Priority= 1, Visibility=true },
                new Capability { Id = ++id, Name = "J2EE", Priority= 1, Visibility=true },
                new Capability { Id = ++id, Name = "C++", Priority= 1, Visibility=true },
                new Capability { Id = ++id, Name = "C", Priority= 1, Visibility=true },
                new Capability { Id = ++id, Name = "STM32", Priority= 1, Visibility=true },
                new Capability { Id = ++id, Name = "CSS", Priority= 1, Visibility=true },
                new Capability { Id = ++id, Name = "Tailwind CSS", Priority= 1, Visibility=true },
                new Capability { Id = ++id, Name = "Bootstrap", Priority= 1, Visibility=true },
                new Capability { Id = ++id, Name = "EF Core", Priority= 1, Visibility=true },
                new Capability { Id = ++id, Name = "SQL", Priority= 1, Visibility=true },
            };

        return seeds;
    }
}