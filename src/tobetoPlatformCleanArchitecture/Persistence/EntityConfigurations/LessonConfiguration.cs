using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("Lessons").HasKey(l => l.Id);

        builder.Property(l => l.Id).HasColumnName("Id").IsRequired();
        builder.Property(l => l.CourseId).HasColumnName("CourseId");
        builder.Property(l => l.Name).HasColumnName("Name");
        builder.Property(l => l.Visibility).HasColumnName("Visibility");
        builder.Property(l => l.Language).HasColumnName("Language");
        builder.Property(l => l.Content).HasColumnName("Content");
        builder.Property(l => l.Duration).HasColumnName("Duration");
        builder.Property(l => l.IsActive).HasColumnName("IsActive");
        builder.Property(l => l.VideoUrl).HasColumnName("VideoUrl");
        builder.Property(l => l.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(l => l.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(l => l.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(l => !l.DeletedDate.HasValue);

        builder.HasData(getSeeds());
    }

    private HashSet<Lesson> getSeeds()
    {
        int id = 0;
        HashSet<Lesson> seeds =
            new()
            {
                new Lesson { Id = ++id, CourseId=1, Name="Python ile Programlama Temelleri", Visibility= true, Language= "T�rk�e", Content= "Python ile Programlama Temelleri a��klamas�", VideoUrl = "S_A_VVSQdpU", Duration=113, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="C# Temelleri 1", Visibility= true, Language= "T�rk�e", Content= "C# Temelleri 1 a��klamas�", VideoUrl = "FB7VUYLyl1I", Duration=161, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="C# Temelleri 2", Visibility= true, Language= "T�rk�e",Content= "C# Temelleri 2 a��klamas�", VideoUrl = "1j68gb1-qOw", Duration=168, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="C# 1", Visibility= true, Language= "T�rk�e",Content= "C# 1 a��klamas�", VideoUrl = "G0sOB_-WkyI", Duration=173, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="C# 2", Visibility= true, Language= "T�rk�e",Content= "C# 2 a��klamas�", VideoUrl = "MU_YQtgdkKA", Duration=172, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="SQL", Visibility= true, Language= "T�rk�e",Content= "SQL a��klamas�", VideoUrl = "r_pbdopB4LU", Duration=201, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="C# 3", Visibility= true, Language= "T�rk�e",Content= "C# 3 a��klamas�", VideoUrl = "qBQOqh844Mo", Duration=177, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Entity Framework", Visibility= true, Language= "T�rk�e",Content= "Entity Framework a��klamas�", VideoUrl = "ow-EHetuNAU", Duration=168, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Kurumsal Yaz�l�m Mimarileri 1", Visibility= true, Language= "T�rk�e",Content= "Kurumsal Yaz�l�m Mimarileri 1 a��klamas�", VideoUrl = "Hgqqoycoh9c", Duration=177, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Kurumsal Yaz�l�m Mimarileri 2", Visibility= true, Language= "T�rk�e",Content= "Kurumsal Yaz�l�m Mimarileri 2 a��klamas�", VideoUrl = "NlAj9dT3MiA", Duration=186, IsActive = true},

                 new Lesson { Id = ++id, CourseId=1, Name="Kurumsal Yaz�l�m Mimarileri 3", Visibility= true, Language= "T�rk�e",Content= "Kurumsal Yaz�l�m Mimarileri 3 a��klamas�", VideoUrl = "LZqMmvgCNx0", Duration=181, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Kurumsal Yaz�l�m Mimarileri 4", Visibility= true, Language= "T�rk�e",Content= "Kurumsal Yaz�l�m Mimarileri 4 a��klamas�", VideoUrl = "cSmUHlnHOXI", Duration=192, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Kurumsal Yaz�l�m Mimarileri 5 ve AOP", Visibility= true, Language= "T�rk�e",Content= "Kurumsal Yaz�l�m Mimarileri 5 ve AOP a��klamas�", VideoUrl = "zdpPm7Q6YE0", Duration=189, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Kurumsal Yaz�l�m Mimarileri 6 ve JWT", Visibility= true, Language= "T�rk�e",Content= "Kurumsal Yaz�l�m Mimarileri 6 ve JWT a��klamas�", VideoUrl = "2DchBG--kAs", Duration=274, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Kurumsal Yaz�l�m Mimarileri 7 ve AOP", Visibility= true, Language= "T�rk�e",Content= "Kurumsal Yaz�l�m Mimarileri 7 ve AOP a��klamas�", VideoUrl = "mbl4BjQMX78", Duration=255, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Angular Giri� 1", Visibility= true, Language= "T�rk�e",Content= "Angular Giri� 1 a��klamas�", VideoUrl = "f_r8SkLWgBI", Duration=241, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Angular Giri� 2", Visibility= true, Language= "T�rk�e",Content= "Angular Giri� 2 a��klamas�", VideoUrl = "2fzL2LDamvM", Duration=194, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Angular Giri� 3", Visibility= true, Language= "T�rk�e",Content= "Angular Giri� 3 a��klamas�", VideoUrl = "3xaRghmo-kU", Duration=174, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Angular Giri� 4", Visibility= true, Language= "T�rk�e",Content= "Angular Giri� 4 a��klamas�", VideoUrl = "-VVVDswfEJw", Duration=181, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Angular Giri� 5", Visibility= true, Language= "T�rk�e",Content= "Angular Giri� 5 a��klamas�", VideoUrl = "Sb1ZpVlS8LA", Duration=176, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Angular Giri� 6", Visibility= true, Language= "T�rk�e",Content= "Angular Giri� 6 a��klamas�", VideoUrl = "obK-YEOuVgY", Duration=154, IsActive = true},

                new Lesson { Id = ++id, CourseId=4, Name="Html 5 Dersleri 1: Plunker Online Edit�r�m�z� Tan�yal�m", Visibility= true, Language= "T�rk�e",Content= "Html 5 Dersleri 1 a��klamas�", VideoUrl = "pkYSPtpvDqc", Duration=4, IsActive = true},

                new Lesson { Id = ++id, CourseId=4, Name="Html 5 Dersleri 2: Html nedir?", Visibility= true, Language= "T�rk�e",Content= "Html 5 Dersleri 2 a��klamas�", VideoUrl = "C8n7li03yJM", Duration=4, IsActive = true},

                new Lesson { Id = ++id, CourseId=4, Name="Html 5 Dersleri 3: Temel Html Elementleri", Visibility= true, Language= "T�rk�e",Content= "Html 5 Dersleri 3 a��klamas�", VideoUrl = "_CyfWwttWfk", Duration=4, IsActive = true},

                new Lesson { Id = ++id, CourseId=4, Name="Html 5 Dersleri 4: Linklerle �al��mak", Visibility= true, Language= "T�rk�e",Content= "Html 5 Dersleri 4 a��klamas�", VideoUrl = "k1uoQWyxixQ", Duration=13, IsActive = true},

                new Lesson { Id = ++id, CourseId=4, Name="Html 5 Dersleri 5: Tablolarla �al��mak", Visibility= true, Language= "T�rk�e",Content= "Html 5 Dersleri 5 a��klamas�", VideoUrl = "aph25fXelME", Duration=6, IsActive = true},

                new Lesson { Id = ++id, CourseId=4, Name="Html 5 Dersleri 6: Formatlama", Visibility= true, Language= "T�rk�e",Content= "Html 5 Dersleri 6 a��klamas�", VideoUrl = "7pT6prRLNX0", Duration=7, IsActive = true},

                new Lesson { Id = ++id, CourseId=4, Name="Html 5 Dersleri 7: Layouts", Visibility= true, Language= "T�rk�e",Content= "Html 5 Dersleri 7 a��klamas�", VideoUrl = "0OqzuBAQ7_A", Duration=8, IsActive = true},

                new Lesson { Id = ++id, CourseId=4, Name="Html 5 Dersleri 8: Form Tagleri", Visibility= true, Language= "T�rk�e",Content= "Html 5 Dersleri 8 a��klamas�", VideoUrl = "5K5mUa_Q1VY", Duration=18, IsActive = true},

                new Lesson { Id = ++id, CourseId=4, Name="Html 5 Dersleri 9: Html 5 �le Gelen Form Tagleri", Visibility= true, Language= "T�rk�e",Content= "Html 5 Dersleri 9 a��klamas�", VideoUrl = "5vKZPDT0gcM", Duration=7, IsActive = true},
            };
        return seeds;
    }
}