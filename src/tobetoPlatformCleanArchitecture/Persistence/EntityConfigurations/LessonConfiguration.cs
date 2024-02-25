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
                new Lesson { Id = ++id, CourseId=1, Name="Python ile Programlama Temelleri", Visibility= true, Language= "Türkçe", Content= "Python ile Programlama Temelleri açýklamasý", VideoUrl = "S_A_VVSQdpU", Duration=113, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="C# Temelleri 1", Visibility= true, Language= "Türkçe", Content= "C# Temelleri 1 açýklamasý", VideoUrl = "FB7VUYLyl1I", Duration=161, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="C# Temelleri 2", Visibility= true, Language= "Türkçe",Content= "C# Temelleri 2 açýklamasý", VideoUrl = "1j68gb1-qOw", Duration=168, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="C# 1", Visibility= true, Language= "Türkçe",Content= "C# 1 açýklamasý", VideoUrl = "G0sOB_-WkyI", Duration=173, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="C# 2", Visibility= true, Language= "Türkçe",Content= "C# 2 açýklamasý", VideoUrl = "MU_YQtgdkKA", Duration=172, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="SQL", Visibility= true, Language= "Türkçe",Content= "SQL açýklamasý", VideoUrl = "r_pbdopB4LU", Duration=201, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="C# 3", Visibility= true, Language= "Türkçe",Content= "C# 3 açýklamasý", VideoUrl = "qBQOqh844Mo", Duration=177, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Entity Framework", Visibility= true, Language= "Türkçe",Content= "Entity Framework açýklamasý", VideoUrl = "ow-EHetuNAU", Duration=168, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Kurumsal Yazýlým Mimarileri 1", Visibility= true, Language= "Türkçe",Content= "Kurumsal Yazýlým Mimarileri 1 açýklamasý", VideoUrl = "Hgqqoycoh9c", Duration=177, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Kurumsal Yazýlým Mimarileri 2", Visibility= true, Language= "Türkçe",Content= "Kurumsal Yazýlým Mimarileri 2 açýklamasý", VideoUrl = "NlAj9dT3MiA", Duration=186, IsActive = true},

                 new Lesson { Id = ++id, CourseId=1, Name="Kurumsal Yazýlým Mimarileri 3", Visibility= true, Language= "Türkçe",Content= "Kurumsal Yazýlým Mimarileri 3 açýklamasý", VideoUrl = "LZqMmvgCNx0", Duration=181, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Kurumsal Yazýlým Mimarileri 4", Visibility= true, Language= "Türkçe",Content= "Kurumsal Yazýlým Mimarileri 4 açýklamasý", VideoUrl = "cSmUHlnHOXI", Duration=192, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Kurumsal Yazýlým Mimarileri 5 ve AOP", Visibility= true, Language= "Türkçe",Content= "Kurumsal Yazýlým Mimarileri 5 ve AOP açýklamasý", VideoUrl = "zdpPm7Q6YE0", Duration=189, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Kurumsal Yazýlým Mimarileri 6 ve JWT", Visibility= true, Language= "Türkçe",Content= "Kurumsal Yazýlým Mimarileri 6 ve JWT açýklamasý", VideoUrl = "2DchBG--kAs", Duration=274, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Kurumsal Yazýlým Mimarileri 7 ve AOP", Visibility= true, Language= "Türkçe",Content= "Kurumsal Yazýlým Mimarileri 7 ve AOP açýklamasý", VideoUrl = "mbl4BjQMX78", Duration=255, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Angular Giriþ 1", Visibility= true, Language= "Türkçe",Content= "Angular Giriþ 1 açýklamasý", VideoUrl = "f_r8SkLWgBI", Duration=241, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Angular Giriþ 2", Visibility= true, Language= "Türkçe",Content= "Angular Giriþ 2 açýklamasý", VideoUrl = "2fzL2LDamvM", Duration=194, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Angular Giriþ 3", Visibility= true, Language= "Türkçe",Content= "Angular Giriþ 3 açýklamasý", VideoUrl = "3xaRghmo-kU", Duration=174, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Angular Giriþ 4", Visibility= true, Language= "Türkçe",Content= "Angular Giriþ 4 açýklamasý", VideoUrl = "-VVVDswfEJw", Duration=181, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Angular Giriþ 5", Visibility= true, Language= "Türkçe",Content= "Angular Giriþ 5 açýklamasý", VideoUrl = "Sb1ZpVlS8LA", Duration=176, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Angular Giriþ 6", Visibility= true, Language= "Türkçe",Content= "Angular Giriþ 6 açýklamasý", VideoUrl = "obK-YEOuVgY", Duration=154, IsActive = true},

                new Lesson { Id = ++id, CourseId=4, Name="Html 5 Dersleri 1: Plunker Online Editörümüzü Tanýyalým", Visibility= true, Language= "Türkçe",Content= "Html 5 Dersleri 1 açýklamasý", VideoUrl = "pkYSPtpvDqc", Duration=4, IsActive = true},

                new Lesson { Id = ++id, CourseId=4, Name="Html 5 Dersleri 2: Html nedir?", Visibility= true, Language= "Türkçe",Content= "Html 5 Dersleri 2 açýklamasý", VideoUrl = "C8n7li03yJM", Duration=4, IsActive = true},

                new Lesson { Id = ++id, CourseId=4, Name="Html 5 Dersleri 3: Temel Html Elementleri", Visibility= true, Language= "Türkçe",Content= "Html 5 Dersleri 3 açýklamasý", VideoUrl = "_CyfWwttWfk", Duration=4, IsActive = true},

                new Lesson { Id = ++id, CourseId=4, Name="Html 5 Dersleri 4: Linklerle Çalýþmak", Visibility= true, Language= "Türkçe",Content= "Html 5 Dersleri 4 açýklamasý", VideoUrl = "k1uoQWyxixQ", Duration=13, IsActive = true},

                new Lesson { Id = ++id, CourseId=4, Name="Html 5 Dersleri 5: Tablolarla Çalýþmak", Visibility= true, Language= "Türkçe",Content= "Html 5 Dersleri 5 açýklamasý", VideoUrl = "aph25fXelME", Duration=6, IsActive = true},

                new Lesson { Id = ++id, CourseId=4, Name="Html 5 Dersleri 6: Formatlama", Visibility= true, Language= "Türkçe",Content= "Html 5 Dersleri 6 açýklamasý", VideoUrl = "7pT6prRLNX0", Duration=7, IsActive = true},

                new Lesson { Id = ++id, CourseId=4, Name="Html 5 Dersleri 7: Layouts", Visibility= true, Language= "Türkçe",Content= "Html 5 Dersleri 7 açýklamasý", VideoUrl = "0OqzuBAQ7_A", Duration=8, IsActive = true},

                new Lesson { Id = ++id, CourseId=4, Name="Html 5 Dersleri 8: Form Tagleri", Visibility= true, Language= "Türkçe",Content= "Html 5 Dersleri 8 açýklamasý", VideoUrl = "5K5mUa_Q1VY", Duration=18, IsActive = true},

                new Lesson { Id = ++id, CourseId=4, Name="Html 5 Dersleri 9: Html 5 Ýle Gelen Form Tagleri", Visibility= true, Language= "Türkçe",Content= "Html 5 Dersleri 9 açýklamasý", VideoUrl = "5vKZPDT0gcM", Duration=7, IsActive = true},
            };
        return seeds;
    }
}