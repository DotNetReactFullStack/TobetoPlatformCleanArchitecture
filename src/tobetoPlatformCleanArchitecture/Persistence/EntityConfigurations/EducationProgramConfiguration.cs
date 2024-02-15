using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EducationProgramConfiguration : IEntityTypeConfiguration<EducationProgram>
{
    public void Configure(EntityTypeBuilder<EducationProgram> builder)
    {
        builder.ToTable("EducationPrograms").HasKey(ep => ep.Id);

        builder.Property(ep => ep.Id).HasColumnName("Id").IsRequired();
        builder.Property(ep => ep.CollegeId).HasColumnName("CollegeId");
        builder.Property(ep => ep.Name).HasColumnName("Name");
        builder.Property(ep => ep.Visibility).HasColumnName("Visibility");
        builder.Property(ep => ep.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ep => ep.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ep => ep.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ep => !ep.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }
    private HashSet<EducationProgram> getSeeds()
    {
        int id = 0;
        int collegeId = 0;
        HashSet<EducationProgram> seeds =
            new()
            {
                new EducationProgram { Id = ++id, CollegeId = ++collegeId, Name = "Matematik", Visibility=true },
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "Bilgisayar Mühendisliði", Visibility=true },
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "Elektrik-Elektronik Mühendisliði", Visibility=true },

                new EducationProgram { Id = ++id, CollegeId = ++collegeId, Name = "Endüstri Mühendisliði", Visibility=true },
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "Kimya", Visibility=true },
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "Makine Mühendisliði", Visibility=true },

                new EducationProgram { Id = ++id, CollegeId = ++collegeId, Name = "Ýnþaat Mühendisliði", Visibility=true },
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "Gýda Mühendisliði", Visibility=true },
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "Yazýlým Mühendisliði", Visibility=true },

                new EducationProgram { Id = ++id, CollegeId = ++collegeId, Name = "Ýngilizce Öðretmenliði", Visibility=true },
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "Ýþletme", Visibility=true },
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "Elektrik-Elektronik Mühendisliði", Visibility=true },

                new EducationProgram { Id = ++id, CollegeId = ++collegeId, Name = "Matematik", Visibility=true },
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "Ekonometri", Visibility=true },
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "Mimarlýk", Visibility=true },

                new EducationProgram { Id = ++id, CollegeId = ++collegeId, Name = "Biyoloji", Visibility=true },
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "Tarih", Visibility=true },
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "Týp", Visibility=true },

                new EducationProgram { Id = ++id, CollegeId = ++collegeId, Name = "Türkçe Öðretmenliði", Visibility=true },
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "Uluslararasý Ýliþkiler", Visibility=true },
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "Veterinerlik", Visibility=true },

            };
        return seeds;
    }
}