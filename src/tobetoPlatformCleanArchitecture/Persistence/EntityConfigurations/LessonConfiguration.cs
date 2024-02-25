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

                new Lesson { Id = ++id, CourseId=5, Name="�stanbul Kodluyor Proje A�amalar�", Visibility= true, Language= "T�rk�e",Content= "�stanbul Kodluyor Proje A�amalar� a��klamas�", VideoUrl = "lIRN7fXQIcQ", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=6, Name="�stanbul Kodluyor Kamp�s Bulu�mas� 2", Visibility= true, Language= "T�rk�e",Content= "�stanbul Kodluyor Kamp�s Bulu�mas� 2 a��klamas�", VideoUrl = "1zMSWuTgqTI", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=7, Name="Java Derslerine Giri�", Visibility= true, Language= "T�rk�e",Content= "Java Derslerine Giri� a��klamas�", VideoUrl = "-XfPd-cQRuo", Duration=1, IsActive = true},
                new Lesson { Id = ++id, CourseId=7, Name="OOP Giri�", Visibility= true, Language= "T�rk�e",Content= "OOP Giri� a��klamas�", VideoUrl = "2Vx_Z-5Dr4I", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=7, Name="OOP - Class & Interface ile S�rd�r�lebilirlik", Visibility= true, Language= "T�rk�e",Content= "OOP - Class & Interface ile S�rd�r�lebilirlik a��klamas�", VideoUrl = "CcutMZm3WtI", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=7, Name="Spring Boot Giri�", Visibility= true, Language= "T�rk�e",Content= "Spring Boot Giri� a��klamas�", VideoUrl = "AMOHXH2uzgY", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=7, Name="Spring Boot 2", Visibility= true, Language= "T�rk�e",Content= "Spring Boot 2 a��klamas�", VideoUrl = "7Qqb4IyULmo", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=7, Name="Spring Boot 3", Visibility= true, Language= "T�rk�e",Content= "Spring Boot 3 a��klamas�", VideoUrl = "hyYJwO3GEic", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=7, Name="Spring Boot 4", Visibility= true, Language= "T�rk�e",Content= "Spring Boot 4 a��klamas�", VideoUrl = "IWv7jLsaxLM", Duration=1, IsActive = true},
                new Lesson { Id = ++id, CourseId=8, Name="Tan�t�m", Visibility= true, Language= "T�rk�e",Content= "Tan�t�m a��klamas�", VideoUrl = "rlKjFEKjXyg", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=8, Name="��lenecek Konular ve Yap�lacak Uygulama Tan�t�m�", Visibility= true, Language= "T�rk�e",Content= "��lenecek Konular ve Yap�lacak Uygulama Tan�t�m� a��klamas�", VideoUrl = "x7_Rmsmkw5g", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=8, Name="NodeJS ve Angular Cli kurulumu", Visibility= true, Language= "T�rk�e",Content= "NodeJS ve Angular Cli kurulumu a��klamas�", VideoUrl = "bA71kJ_ELek", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=8, Name="Proje olu�turma", Visibility= true, Language= "T�rk�e",Content= "Proje olu�turma a��klamas�", VideoUrl = "v9FxSVjWTic", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=8, Name="K�saca Klas�r Yap�s� ve Dosyalar", Visibility= true, Language= "T�rk�e",Content= "K�saca Klas�r Yap�s� ve Dosyalar a��klamas�", VideoUrl = "raSrjyUjFbc", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=8, Name="TypeScript", Visibility= true, Language= "T�rk�e",Content= "TypeScript a��klamas�", VideoUrl = "IA9b7swmP4o", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=8, Name="Components", Visibility= true, Language= "T�rk�e",Content= "Components a��klamas�", VideoUrl = "ofRjx87jGlw", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=8, Name="De�i�kenler ve Veri Tipleri", Visibility= true, Language= "T�rk�e",Content= "De�i�kenler ve Veri Tipleri a��klamas�", VideoUrl = "0uHcZekbNcE", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=8, Name="Services", Visibility= true, Language= "T�rk�e",Content= "Services a��klamas�", VideoUrl = "Pxl5LSvRu74", Duration=1, IsActive = true},

                new Lesson { Id = ++id, CourseId=8, Name="ngIf ve ngFor", Visibility= true, Language= "T�rk�e",Content= "ngIf ve ngFor a��klamas�", VideoUrl = "j3F6A7wK-S4", Duration=1, IsActive = true},

                //Flutter Course;
                new Lesson { Id = ++id, CourseId=9, Name="Flutter Mobil Programlama Kamp�", Visibility= true, Language= "T�rk�e",Content= "Flutter Mobil Programlama Kamp� a��klamas�", VideoUrl = "oISIcfHAzm4", Duration=355, IsActive = true},

                new Lesson { Id = ++id, CourseId=9, Name="Flutter SDK & Android Studio & Visual Studio Code Kurulumu", Visibility= true, Language= "T�rk�e",Content= "Flutter SDK & Android Studio & Visual Studio Code Kurulumu a��klamas�", VideoUrl = "uyYBewriDT8", Duration=56, IsActive = true},

                //Yemek Sipari�i uygulamas�
                new Lesson { Id = ++id, CourseId=10, Name="Food Delivery App | Part 1", Visibility= true, Language= "T�rk�e",Content= "Food Delivery App | Part 1 a��klamas�", VideoUrl = "7dAt-JMSCVQ", Duration=720, IsActive = true},
                new Lesson { Id = ++id, CourseId=10, Name="Full Course With API | Part 2", Visibility= true, Language= "T�rk�e",Content= "Full Course With API | Part 2 a��klamas�", VideoUrl = "GQJovou6zuE", Duration=710, IsActive = true},
                new Lesson { Id = ++id, CourseId=10, Name="Flutter Ecommerce App | Part 3", Visibility= true, Language= "T�rk�e",Content= "Flutter Ecommerce App | Part 3 a��klamas�", VideoUrl = "qapb-_gMZRs", Duration=193, IsActive = true},

                //C# ve .NET M�lakatlar�ndan En �nde Ge�me Teknikleri - Part 1
                new Lesson { Id = ++id, CourseId=11, Name="Giri�", Visibility= true, Language= "T�rk�e",Content= "Giri� a��klamas�", VideoUrl = "iRBN3p4J_xk", Duration=2, IsActive = true},

                new Lesson { Id = ++id, CourseId=11, Name="Ne �stiyorsun?", Visibility= true, Language= "T�rk�e",Content= "Ne �stiyorsun? a��klamas�", VideoUrl = "7h0h93LS8hw", Duration=2, IsActive = true},

                new Lesson { Id = ++id, CourseId=11, Name="Organizasyonel K�lt�r� Ke�fedin", Visibility= true, Language= "T�rk�e",Content= "Organizasyonel K�lt�r� Ke�fedin a��klamas�", VideoUrl = "46zp-3139M4", Duration=2, IsActive = true},
                new Lesson { Id = ++id, CourseId=11, Name="De�er ve Referans Tipler", Visibility= true, Language= "T�rk�e",Content= "De�er ve Referans Tipler a��klamas�", VideoUrl = "_giFJC-07yw?", Duration=2, IsActive = true},

                new Lesson { Id = ++id, CourseId=11, Name="�nterface nedir? Ne i�e yarar?", Visibility= true, Language= "T�rk�e",Content= "�nterface nedir? Ne i�e yarar? a��klamas�", VideoUrl = "GyCTVZTIOKM", Duration=2, IsActive = true},

                //C# ve .NET M�lakatlar�ndan En �nde Ge�me Teknikleri - Part 2

                new Lesson { Id = ++id, CourseId=11, Name="Framework ve Library Kavramlar� Nedir?", Visibility= true, Language= "T�rk�e",Content= "Framework ve Library Kavramlar� Nedir? a��klamas�", VideoUrl = "5dQeNa0Uzns", Duration=2, IsActive = true},

                new Lesson { Id = ++id, CourseId=11, Name="SOLID Prensipleri Nedir?", Visibility= true, Language= "T�rk�e",Content= "SOLID Prensipleri Nedir? a��klamas�", VideoUrl = "gdjcKwWxe08", Duration=2, IsActive = true},

                new Lesson { Id = ++id, CourseId=11, Name="Single Responsibility Principle", Visibility= true, Language= "T�rk�e",Content= "Single Responsibility Principle a��klamas�", VideoUrl = "AX6nDbsP2ME", Duration=2, IsActive = true},

                new Lesson { Id = ++id, CourseId=11, Name="Open Closed Principle ", Visibility= true, Language= "T�rk�e",Content= "Open Closed Principle  a��klamas�", VideoUrl = "tx2DjE-VwOY", Duration=2, IsActive = true},

                new Lesson { Id = ++id, CourseId=11, Name="Liskov's Subsititution Principle", Visibility= true, Language= "T�rk�e",Content= "Liskov's Subsititution Principle a��klamas�", VideoUrl = "M2bDfaZvTTs", Duration=2, IsActive = true},
            };
        return seeds;
    }
}