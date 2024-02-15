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
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "Bilgisayar M�hendisli�i", Visibility=true },
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "Elektrik-Elektronik M�hendisli�i", Visibility=true },

                new EducationProgram { Id = ++id, CollegeId = ++collegeId, Name = "End�stri M�hendisli�i", Visibility=true },
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "Kimya", Visibility=true },
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "Makine M�hendisli�i", Visibility=true },

                new EducationProgram { Id = ++id, CollegeId = ++collegeId, Name = "�n�aat M�hendisli�i", Visibility=true },
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "G�da M�hendisli�i", Visibility=true },
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "Yaz�l�m M�hendisli�i", Visibility=true },

                new EducationProgram { Id = ++id, CollegeId = ++collegeId, Name = "�ngilizce ��retmenli�i", Visibility=true },
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "��letme", Visibility=true },
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "Elektrik-Elektronik M�hendisli�i", Visibility=true },

                new EducationProgram { Id = ++id, CollegeId = ++collegeId, Name = "Matematik", Visibility=true },
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "Ekonometri", Visibility=true },
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "Mimarl�k", Visibility=true },

                new EducationProgram { Id = ++id, CollegeId = ++collegeId, Name = "Biyoloji", Visibility=true },
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "Tarih", Visibility=true },
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "T�p", Visibility=true },

                new EducationProgram { Id = ++id, CollegeId = ++collegeId, Name = "T�rk�e ��retmenli�i", Visibility=true },
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "Uluslararas� �li�kiler", Visibility=true },
                new EducationProgram { Id = ++id, CollegeId = collegeId, Name = "Veterinerlik", Visibility=true },

            };
        return seeds;
    }
}