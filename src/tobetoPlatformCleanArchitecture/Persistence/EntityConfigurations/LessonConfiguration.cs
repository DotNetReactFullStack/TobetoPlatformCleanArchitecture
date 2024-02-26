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
                new Lesson { Id = ++id, CourseId=1, Name="Python ile Programlama Temelleri", Visibility= true, Language= "Türkçe", Content= "Python ile Programlama Temelleri açıklaması", VideoUrl = "S_A_VVSQdpU", Duration=113, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="C# Temelleri 1", Visibility= true, Language= "Türkçe", Content= "C# Temelleri 1 açıklaması", VideoUrl = "FB7VUYLyl1I", Duration=161, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="C# Temelleri 2", Visibility= true, Language= "Türkçe",Content= "C# Temelleri 2 açıklaması", VideoUrl = "1j68gb1-qOw", Duration=168, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="C# 1", Visibility= true, Language= "Türkçe",Content= "C# 1 açıklaması", VideoUrl = "G0sOB_-WkyI", Duration=173, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="C# 2", Visibility= true, Language= "Türkçe",Content= "C# 2 açıklaması", VideoUrl = "MU_YQtgdkKA", Duration=172, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="SQL", Visibility= true, Language= "Türkçe",Content= "SQL açıklaması", VideoUrl = "r_pbdopB4LU", Duration=201, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="C# 3", Visibility= true, Language= "Türkçe",Content= "C# 3 açıklaması", VideoUrl = "qBQOqh844Mo", Duration=177, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Entity Framework", Visibility= true, Language= "Türkçe",Content= "Entity Framework açıklaması", VideoUrl = "ow-EHetuNAU", Duration=168, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Kurumsal Yazılım Mimarileri 1", Visibility= true, Language= "Türkçe",Content= "Kurumsal Yazılım Mimarileri 1 açıklaması", VideoUrl = "Hgqqoycoh9c", Duration=177, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Kurumsal Yazılım Mimarileri 2", Visibility= true, Language= "Türkçe",Content= "Kurumsal Yazılım Mimarileri 2 açıklaması", VideoUrl = "NlAj9dT3MiA", Duration=186, IsActive = true},

                 new Lesson { Id = ++id, CourseId=1, Name="Kurumsal Yazılım Mimarileri 3", Visibility= true, Language= "Türkçe",Content= "Kurumsal Yazılım Mimarileri 3 açıklaması", VideoUrl = "LZqMmvgCNx0", Duration=181, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Kurumsal Yazılım Mimarileri 4", Visibility= true, Language= "Türkçe",Content= "Kurumsal Yazılım Mimarileri 4 açıklaması", VideoUrl = "cSmUHlnHOXI", Duration=192, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Kurumsal Yazılım Mimarileri 5 ve AOP", Visibility= true, Language= "Türkçe",Content= "Kurumsal Yazılım Mimarileri 5 ve AOP açıklaması", VideoUrl = "zdpPm7Q6YE0", Duration=189, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Kurumsal Yazılım Mimarileri 6 ve JWT", Visibility= true, Language= "Türkçe",Content= "Kurumsal Yazılım Mimarileri 6 ve JWT açıklaması", VideoUrl = "2DchBG--kAs", Duration=274, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Kurumsal Yazılım Mimarileri 7 ve AOP", Visibility= true, Language= "Türkçe",Content= "Kurumsal Yazılım Mimarileri 7 ve AOP açıklaması", VideoUrl = "mbl4BjQMX78", Duration=255, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Angular Giriş 1", Visibility= true, Language= "Türkçe",Content= "Angular Giriş 1 açıklaması", VideoUrl = "f_r8SkLWgBI", Duration=241, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Angular Giriş 2", Visibility= true, Language= "Türkçe",Content= "Angular Giriş 2 açıklaması", VideoUrl = "2fzL2LDamvM", Duration=194, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Angular Giriş 3", Visibility= true, Language= "Türkçe",Content= "Angular Giriş 3 açıklaması", VideoUrl = "3xaRghmo-kU", Duration=174, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Angular Giriş 4", Visibility= true, Language= "Türkçe",Content= "Angular Giriş 4 açıklaması", VideoUrl = "-VVVDswfEJw", Duration=181, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Angular Giriş 5", Visibility= true, Language= "Türkçe",Content= "Angular Giriş 5 açıklaması", VideoUrl = "Sb1ZpVlS8LA", Duration=176, IsActive = true},

                new Lesson { Id = ++id, CourseId=1, Name="Angular Giriş 6", Visibility= true, Language= "Türkçe",Content= "Angular Giriş 6 açıklaması", VideoUrl = "obK-YEOuVgY", Duration=154, IsActive = true},

                new Lesson { Id = ++id, CourseId=4, Name="Plunker Online Editörümüzü Tanıyalım", Visibility= true, Language= "Türkçe",Content= "Html 5 Dersleri 1 açıklaması", VideoUrl = "pkYSPtpvDqc", Duration=4, IsActive = true},

                new Lesson { Id = ++id, CourseId=4, Name="Html nedir?", Visibility= true, Language= "Türkçe",Content= "Html 5 Dersleri 2 açıklaması", VideoUrl = "C8n7li03yJM", Duration=4, IsActive = true},

                new Lesson { Id = ++id, CourseId=4, Name="Temel Html Elementleri", Visibility= true, Language= "Türkçe",Content= "Html 5 Dersleri 3 açıklaması", VideoUrl = "_CyfWwttWfk", Duration=4, IsActive = true},

                new Lesson { Id = ++id, CourseId=4, Name="Linklerle Çalışmak", Visibility= true, Language= "Türkçe",Content= "Html 5 Dersleri 4 açıklaması", VideoUrl = "k1uoQWyxixQ", Duration=13, IsActive = true},

                new Lesson { Id = ++id, CourseId=4, Name="Tablolarla Çalışmak", Visibility= true, Language= "Türkçe",Content= "Html 5 Dersleri 5 açıklaması", VideoUrl = "aph25fXelME", Duration=6, IsActive = true},

                new Lesson { Id = ++id, CourseId=4, Name="Formatlama", Visibility= true, Language= "Türkçe",Content= "Html 5 Dersleri 6 açıklaması", VideoUrl = "7pT6prRLNX0", Duration=7, IsActive = true},

                new Lesson { Id = ++id, CourseId=4, Name="Layouts", Visibility= true, Language= "Türkçe",Content= "Html 5 Dersleri 7 açıklaması", VideoUrl = "0OqzuBAQ7_A", Duration=8, IsActive = true},

                new Lesson { Id = ++id, CourseId=4, Name="Form Tagleri", Visibility= true, Language= "Türkçe",Content= "Html 5 Dersleri 8 açıklaması", VideoUrl = "5K5mUa_Q1VY", Duration=18, IsActive = true},

                new Lesson { Id = ++id, CourseId=4, Name="Html 5 İle Gelen Form Tagleri", Visibility= true, Language= "Türkçe",Content= "Html 5 Dersleri 9 açıklaması", VideoUrl = "5vKZPDT0gcM", Duration=7, IsActive = true},

                new Lesson { Id = ++id, CourseId=5, Name="İstanbul Kodluyor Proje Aşamaları", Visibility= true, Language= "Türkçe",Content= "İstanbul Kodluyor Proje Aşamaları açıklaması", VideoUrl = "lIRN7fXQIcQ", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=6, Name="İstanbul Kodluyor Kampüs Buluşması 2", Visibility= true, Language= "Türkçe",Content= "İstanbul Kodluyor Kampüs Buluşması 2 açıklaması", VideoUrl = "1zMSWuTgqTI", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=7, Name="Java Derslerine Giriş", Visibility= true, Language= "Türkçe",Content= "Java Derslerine Giriş açıklaması", VideoUrl = "-XfPd-cQRuo", Duration=1, IsActive = true},
                new Lesson { Id = ++id, CourseId=7, Name="OOP Giriş", Visibility= true, Language= "Türkçe",Content= "OOP Giriş açıklaması", VideoUrl = "2Vx_Z-5Dr4I", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=7, Name="OOP - Class & Interface ile Sürdürülebilirlik", Visibility= true, Language= "Türkçe",Content= "OOP - Class & Interface ile Sürdürülebilirlik açıklaması", VideoUrl = "CcutMZm3WtI", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=7, Name="Spring Boot Giriş", Visibility= true, Language= "Türkçe",Content= "Spring Boot Giriş açıklaması", VideoUrl = "AMOHXH2uzgY", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=7, Name="Spring Boot 2", Visibility= true, Language= "Türkçe",Content= "Spring Boot 2 açıklaması", VideoUrl = "7Qqb4IyULmo", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=7, Name="Spring Boot 3", Visibility= true, Language= "Türkçe",Content= "Spring Boot 3 açıklaması", VideoUrl = "hyYJwO3GEic", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=7, Name="Spring Boot 4", Visibility= true, Language= "Türkçe",Content= "Spring Boot 4 açıklaması", VideoUrl = "IWv7jLsaxLM", Duration=1, IsActive = true},
                new Lesson { Id = ++id, CourseId=8, Name="Tanıtım", Visibility= true, Language= "Türkçe",Content= "Tanıtım açıklaması", VideoUrl = "rlKjFEKjXyg", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=8, Name="İşlenecek Konular ve Yapılacak Uygulama Tanıtımı", Visibility= true, Language= "Türkçe",Content= "İşlenecek Konular ve Yapılacak Uygulama Tanıtımı açıklaması", VideoUrl = "x7_Rmsmkw5g", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=8, Name="NodeJS ve Angular Cli kurulumu", Visibility= true, Language= "Türkçe",Content= "NodeJS ve Angular Cli kurulumu açıklaması", VideoUrl = "bA71kJ_ELek", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=8, Name="Proje oluşturma", Visibility= true, Language= "Türkçe",Content= "Proje oluşturma açıklaması", VideoUrl = "v9FxSVjWTic", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=8, Name="Kısaca Klasör Yapısı ve Dosyalar", Visibility= true, Language= "Türkçe",Content= "Kısaca Klasör Yapısı ve Dosyalar açıklaması", VideoUrl = "raSrjyUjFbc", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=8, Name="TypeScript", Visibility= true, Language= "Türkçe",Content= "TypeScript açıklaması", VideoUrl = "IA9b7swmP4o", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=8, Name="Components", Visibility= true, Language= "Türkçe",Content= "Components açıklaması", VideoUrl = "ofRjx87jGlw", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=8, Name="Değişkenler ve Veri Tipleri", Visibility= true, Language= "Türkçe",Content= "Değişkenler ve Veri Tipleri açıklaması", VideoUrl = "0uHcZekbNcE", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=8, Name="Services", Visibility= true, Language= "Türkçe",Content= "Services açıklaması", VideoUrl = "Pxl5LSvRu74", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=8, Name="ngIf ve ngFor", Visibility= true, Language= "Türkçe",Content= "ngIf ve ngFor açıklaması", VideoUrl = "j3F6A7wK-S4", Duration=1, IsActive = true},

                //Flutter Course;
                new Lesson { Id = ++id, CourseId=9, Name="Flutter Mobil Programlama Kampı", Visibility= true, Language= "Türkçe",Content= "Flutter Mobil Programlama Kampı açıklaması", VideoUrl = "oISIcfHAzm4", Duration=355, IsActive = true},

                new Lesson { Id = ++id, CourseId=9, Name="Flutter SDK & Android Studio & Visual Studio Code Kurulumu", Visibility= true, Language= "Türkçe",Content= "Flutter SDK & Android Studio & Visual Studio Code Kurulumu açıklaması", VideoUrl = "uyYBewriDT8", Duration=56, IsActive = true},

                //Yemek Siparişi uygulaması
                new Lesson { Id = ++id, CourseId=10, Name="Food Delivery App | Part 1", Visibility= true, Language= "Türkçe",Content= "Food Delivery App | Part 1 açıklaması", VideoUrl = "7dAt-JMSCVQ", Duration=720, IsActive = true},
                new Lesson { Id = ++id, CourseId=10, Name="Full Course With API | Part 2", Visibility= true, Language= "Türkçe",Content= "Full Course With API | Part 2 açıklaması", VideoUrl = "GQJovou6zuE", Duration=710, IsActive = true},
                new Lesson { Id = ++id, CourseId=10, Name="Flutter Ecommerce App | Part 3", Visibility= true, Language= "Türkçe",Content= "Flutter Ecommerce App | Part 3 açıklaması", VideoUrl = "qapb-_gMZRs", Duration=193, IsActive = true},

                //C# ve .NET Mülakatlarından En Önde Geçme Teknikleri - Part 1
                new Lesson { Id = ++id, CourseId=11, Name="Giriş", Visibility= true, Language= "Türkçe",Content= "Giriş açıklaması", VideoUrl = "iRBN3p4J_xk", Duration=2, IsActive = true},

                new Lesson { Id = ++id, CourseId=11, Name="Ne İstiyorsun?", Visibility= true, Language= "Türkçe",Content= "Ne İstiyorsun? açıklaması", VideoUrl = "7h0h93LS8hw", Duration=2, IsActive = true},

                new Lesson { Id = ++id, CourseId=11, Name="Organizasyonel Kültürü Keşfedin", Visibility= true, Language= "Türkçe",Content= "Organizasyonel Kültürü Keşfedin açıklaması", VideoUrl = "46zp-3139M4", Duration=2, IsActive = true},
                new Lesson { Id = ++id, CourseId=11, Name="Değer ve Referans Tipler", Visibility= true, Language= "Türkçe",Content= "Değer ve Referans Tipler açıklaması", VideoUrl = "_giFJC-07yw?", Duration=2, IsActive = true},

                new Lesson { Id = ++id, CourseId=11, Name="Interface nedir? Ne işe yarar?", Visibility= true, Language= "Türkçe",Content= "Interface nedir? Ne işe yarar? açıklaması", VideoUrl = "GyCTVZTIOKM", Duration=2, IsActive = true},

                //C# ve .NET Mülakatlarından En Önde Geçme Teknikleri - Part 2

                new Lesson { Id = ++id, CourseId=12, Name="Framework ve Library Kavramlar Nedir?", Visibility= true, Language= "Türkçe",Content= "Framework ve Library Kavramlar Nedir? açıklaması", VideoUrl = "5dQeNa0Uzns", Duration=2, IsActive = true},

                new Lesson { Id = ++id, CourseId=12, Name="SOLID Prensipleri Nedir?", Visibility= true, Language= "Türkçe",Content= "SOLID Prensipleri Nedir? açıklaması", VideoUrl = "gdjcKwWxe08", Duration=2, IsActive = true},

                new Lesson { Id = ++id, CourseId=12, Name="Single Responsibility Principle", Visibility= true, Language= "Türkçe",Content= "Single Responsibility Principle açıklaması", VideoUrl = "AX6nDbsP2ME", Duration=2, IsActive = true},

                new Lesson { Id = ++id, CourseId=12, Name="Open Closed Principle ", Visibility= true, Language= "Türkçe",Content= "Open Closed Principle  açıklaması", VideoUrl = "tx2DjE-VwOY", Duration=2, IsActive = true},

                new Lesson { Id = ++id, CourseId=12, Name="Liskov's Subsititution Principle", Visibility= true, Language= "Türkçe",Content= "Liskov's Subsititution Principle açıklaması", VideoUrl = "M2bDfaZvTTs", Duration=2, IsActive = true},
            };
        return seeds;
    }
}