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

                new Lesson { Id = ++id, CourseId=5, Name="Ýstanbul Kodluyor Proje Aþamalarý", Visibility= true, Language= "Türkçe",Content= "Ýstanbul Kodluyor Proje Aþamalarý açýklamasý", VideoUrl = "lIRN7fXQIcQ", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=6, Name="Ýstanbul Kodluyor Kampüs Buluþmasý 2", Visibility= true, Language= "Türkçe",Content= "Ýstanbul Kodluyor Kampüs Buluþmasý 2 açýklamasý", VideoUrl = "1zMSWuTgqTI", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=7, Name="Java Derslerine Giriþ", Visibility= true, Language= "Türkçe",Content= "Java Derslerine Giriþ açýklamasý", VideoUrl = "-XfPd-cQRuo", Duration=1, IsActive = true},
                new Lesson { Id = ++id, CourseId=7, Name="OOP Giriþ", Visibility= true, Language= "Türkçe",Content= "OOP Giriþ açýklamasý", VideoUrl = "2Vx_Z-5Dr4I", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=7, Name="OOP - Class & Interface ile Sürdürülebilirlik", Visibility= true, Language= "Türkçe",Content= "OOP - Class & Interface ile Sürdürülebilirlik açýklamasý", VideoUrl = "CcutMZm3WtI", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=7, Name="Spring Boot Giriþ", Visibility= true, Language= "Türkçe",Content= "Spring Boot Giriþ açýklamasý", VideoUrl = "AMOHXH2uzgY", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=7, Name="Spring Boot 2", Visibility= true, Language= "Türkçe",Content= "Spring Boot 2 açýklamasý", VideoUrl = "7Qqb4IyULmo", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=7, Name="Spring Boot 3", Visibility= true, Language= "Türkçe",Content= "Spring Boot 3 açýklamasý", VideoUrl = "hyYJwO3GEic", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=7, Name="Spring Boot 4", Visibility= true, Language= "Türkçe",Content= "Spring Boot 4 açýklamasý", VideoUrl = "IWv7jLsaxLM", Duration=1, IsActive = true},
                new Lesson { Id = ++id, CourseId=8, Name="Tanýtým", Visibility= true, Language= "Türkçe",Content= "Tanýtým açýklamasý", VideoUrl = "rlKjFEKjXyg", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=8, Name="Ýþlenecek Konular ve Yapýlacak Uygulama Tanýtýmý", Visibility= true, Language= "Türkçe",Content= "Ýþlenecek Konular ve Yapýlacak Uygulama Tanýtýmý açýklamasý", VideoUrl = "x7_Rmsmkw5g", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=8, Name="NodeJS ve Angular Cli kurulumu", Visibility= true, Language= "Türkçe",Content= "NodeJS ve Angular Cli kurulumu açýklamasý", VideoUrl = "bA71kJ_ELek", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=8, Name="Proje oluþturma", Visibility= true, Language= "Türkçe",Content= "Proje oluþturma açýklamasý", VideoUrl = "v9FxSVjWTic", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=8, Name="Kýsaca Klasör Yapýsý ve Dosyalar", Visibility= true, Language= "Türkçe",Content= "Kýsaca Klasör Yapýsý ve Dosyalar açýklamasý", VideoUrl = "raSrjyUjFbc", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=8, Name="TypeScript", Visibility= true, Language= "Türkçe",Content= "TypeScript açýklamasý", VideoUrl = "IA9b7swmP4o", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=8, Name="Components", Visibility= true, Language= "Türkçe",Content= "Components açýklamasý", VideoUrl = "ofRjx87jGlw", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=8, Name="Deðiþkenler ve Veri Tipleri", Visibility= true, Language= "Türkçe",Content= "Deðiþkenler ve Veri Tipleri açýklamasý", VideoUrl = "0uHcZekbNcE", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=8, Name="Services", Visibility= true, Language= "Türkçe",Content= "Services açýklamasý", VideoUrl = "Pxl5LSvRu74", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=8, Name="ngIf ve ngFor", Visibility= true, Language= "Türkçe",Content= "ngIf ve ngFor açýklamasý", VideoUrl = "j3F6A7wK-S4", Duration=1, IsActive = true},

                //Flutter Course;
                new Lesson { Id = ++id, CourseId=9, Name="Flutter Mobil Programlama Kampý", Visibility= true, Language= "Türkçe",Content= "Flutter Mobil Programlama Kampý açýklamasý", VideoUrl = "oISIcfHAzm4", Duration=355, IsActive = true},

                new Lesson { Id = ++id, CourseId=9, Name="Flutter SDK & Android Studio & Visual Studio Code Kurulumu", Visibility= true, Language= "Türkçe",Content= "Flutter SDK & Android Studio & Visual Studio Code Kurulumu açýklamasý", VideoUrl = "uyYBewriDT8", Duration=56, IsActive = true},

                //Yemek Sipariþi uygulamasý
                new Lesson { Id = ++id, CourseId=10, Name="Food Delivery App | Part 1", Visibility= true, Language= "Türkçe",Content= "Food Delivery App | Part 1 açýklamasý", VideoUrl = "7dAt-JMSCVQ", Duration=720, IsActive = true},
                new Lesson { Id = ++id, CourseId=10, Name="Full Course With API | Part 2", Visibility= true, Language= "Türkçe",Content= "Full Course With API | Part 2 açýklamasý", VideoUrl = "GQJovou6zuE", Duration=710, IsActive = true},
                new Lesson { Id = ++id, CourseId=10, Name="Flutter Ecommerce App | Part 3", Visibility= true, Language= "Türkçe",Content= "Flutter Ecommerce App | Part 3 açýklamasý", VideoUrl = "qapb-_gMZRs", Duration=193, IsActive = true},

                //C# ve .NET Mülakatlarýndan En Önde Geçme Teknikleri - Part 1
                new Lesson { Id = ++id, CourseId=11, Name="Giriþ", Visibility= true, Language= "Türkçe",Content= "Giriþ açýklamasý", VideoUrl = "iRBN3p4J_xk", Duration=2, IsActive = true},

                new Lesson { Id = ++id, CourseId=11, Name="Ne Ýstiyorsun?", Visibility= true, Language= "Türkçe",Content= "Ne Ýstiyorsun? açýklamasý", VideoUrl = "7h0h93LS8hw", Duration=2, IsActive = true},

                new Lesson { Id = ++id, CourseId=11, Name="Organizasyonel Kültürü Keþfedin", Visibility= true, Language= "Türkçe",Content= "Organizasyonel Kültürü Keþfedin açýklamasý", VideoUrl = "46zp-3139M4", Duration=2, IsActive = true},
                new Lesson { Id = ++id, CourseId=11, Name="Deðer ve Referans Tipler", Visibility= true, Language= "Türkçe",Content= "Deðer ve Referans Tipler açýklamasý", VideoUrl = "_giFJC-07yw?", Duration=2, IsActive = true},

                new Lesson { Id = ++id, CourseId=11, Name="Ýnterface nedir? Ne iþe yarar?", Visibility= true, Language= "Türkçe",Content= "Ýnterface nedir? Ne iþe yarar? açýklamasý", VideoUrl = "GyCTVZTIOKM", Duration=2, IsActive = true},

                //C# ve .NET Mülakatlarýndan En Önde Geçme Teknikleri - Part 2

                new Lesson { Id = ++id, CourseId=11, Name="Framework ve Library Kavramlarý Nedir?", Visibility= true, Language= "Türkçe",Content= "Framework ve Library Kavramlarý Nedir? açýklamasý", VideoUrl = "5dQeNa0Uzns", Duration=2, IsActive = true},

                new Lesson { Id = ++id, CourseId=11, Name="SOLID Prensipleri Nedir?", Visibility= true, Language= "Türkçe",Content= "SOLID Prensipleri Nedir? açýklamasý", VideoUrl = "gdjcKwWxe08", Duration=2, IsActive = true},

                new Lesson { Id = ++id, CourseId=11, Name="Single Responsibility Principle", Visibility= true, Language= "Türkçe",Content= "Single Responsibility Principle açýklamasý", VideoUrl = "AX6nDbsP2ME", Duration=2, IsActive = true},

                new Lesson { Id = ++id, CourseId=11, Name="Open Closed Principle ", Visibility= true, Language= "Türkçe",Content= "Open Closed Principle  açýklamasý", VideoUrl = "tx2DjE-VwOY", Duration=2, IsActive = true},

                new Lesson { Id = ++id, CourseId=11, Name="Liskov's Subsititution Principle", Visibility= true, Language= "Türkçe",Content= "Liskov's Subsititution Principle açýklamasý", VideoUrl = "M2bDfaZvTTs", Duration=2, IsActive = true},
            };
        return seeds;
    }
}