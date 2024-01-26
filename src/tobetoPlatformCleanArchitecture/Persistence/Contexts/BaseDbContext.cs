using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Domain.Entities;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Capability> Capabilities { get; set; }
    public DbSet<AccountCapability> AccountCapabilities { get; set; }
    public DbSet<ForeignLanguageLevel> ForeignLanguageLevels { get; set; }
    public DbSet<ForeignLanguage> ForeignLanguages { get; set; }
    public DbSet<AccountForeignLanguageMetadata> AccountForeignLanguageMetadatas { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<AccountCertificate> AccountCertificates { get; set; }
    public DbSet<SocialMediaPlatform> SocialMediaPlatforms { get; set; }
    public DbSet<AccountSocialMediaPlatform> AccountSocialMediaPlatforms { get; set; }
    public DbSet<GraduationStatus> GraduationStatuses { get; set; }
    public DbSet<College> Colleges { get; set; }
    public DbSet<EducationProgram> EducationPrograms { get; set; }
    public DbSet<AccountCollageMetadata> AccountCollageMetadatas { get; set; }
    public DbSet<SurveyType> SurveyTypes { get; set; }
    public DbSet<Survey> Surveys { get; set; }
    public DbSet<OrganizationType> OrganizationTypes { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<AnnouncementType> AnnouncementTypes { get; set; }
    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<QuestionCategory> QuestionCategories { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<ExamQuestion> ExamQuestions { get; set; }
    public DbSet<ClassroomExam> ClassroomExams { get; set; }
    public DbSet<AccountExamResult> AccountExamResults { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<AccountClassroom> AccountClassrooms { get; set; }
    public DbSet<AccountLearningPath> AccountLearningPaths { get; set; }
    public DbSet<CourseLearningPath> CourseLearningPaths { get; set; }
    public DbSet<LearningPath> LearningPaths { get; set; }
    public DbSet<CourseCategory> CourseCategories { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<AccountCourse> AccountCourses { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<AccountLesson> AccountLessons { get; set; }
    public DbSet<RecourseStep> RecourseSteps { get; set; }
    public DbSet<Recourse> Recourses { get; set; }
    public DbSet<AccountRecourse> AccountRecourses { get; set; }
    public DbSet<AccountAnnouncement> AccountAnnouncements { get; set; }
    public DbSet<Experience> Experiences { get; set; }


    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {
        Configuration = configuration;
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
