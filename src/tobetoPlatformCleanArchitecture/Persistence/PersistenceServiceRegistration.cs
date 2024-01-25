using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(
                        options => options
                        .UseSqlServer(configuration.GetConnectionString("TobetoPlatformConnectionString")));
        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IDistrictRepository, DistrictRepository>();
        services.AddScoped<ICapabilityRepository, CapabilityRepository>();
        services.AddScoped<IAccountCapabilityRepository, AccountCapabilityRepository>();
        services.AddScoped<IForeignLanguageLevelRepository, ForeignLanguageLevelRepository>();
        services.AddScoped<IForeignLanguageRepository, ForeignLanguageRepository>();
        services.AddScoped<IAccountForeignLanguageMetadataRepository, AccountForeignLanguageMetadataRepository>();
        services.AddScoped<ICertificateRepository, CertificateRepository>();
        services.AddScoped<IAccountCertificateRepository, AccountCertificateRepository>();
        services.AddScoped<ISocialMediaPlatformRepository, SocialMediaPlatformRepository>();
        services.AddScoped<IAccountSocialMediaPlatformRepository, AccountSocialMediaPlatformRepository>();
        services.AddScoped<IGraduationStatusRepository, GraduationStatusRepository>();
        services.AddScoped<ICollegeRepository, CollegeRepository>();
        services.AddScoped<IEducationProgramRepository, EducationProgramRepository>();
        services.AddScoped<IAccountCollageMetadataRepository, AccountCollageMetadataRepository>();
        services.AddScoped<ISurveyTypeRepository, SurveyTypeRepository>();
        services.AddScoped<ISurveyRepository, SurveyRepository>();
        services.AddScoped<IOrganizationTypeRepository, OrganizationTypeRepository>();
        services.AddScoped<IOrganizationRepository, OrganizationRepository>();
        services.AddScoped<IAnnouncementTypeRepository, AnnouncementTypeRepository>();
        services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
        services.AddScoped<IQuestionCategoryRepository, QuestionCategoryRepository>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<IAnswerRepository, AnswerRepository>();
        services.AddScoped<IExamRepository, ExamRepository>();
        services.AddScoped<IExamQuestionRepository, ExamQuestionRepository>();
        services.AddScoped<IClassroomExamRepository, ClassroomExamRepository>();
        services.AddScoped<IAccountExamResultRepository, AccountExamResultRepository>();
        services.AddScoped<IClassroomRepository, ClassroomRepository>();
        services.AddScoped<IAccountClassroomRepository, AccountClassroomRepository>();
        services.AddScoped<IAccountLearningPathRepository, AccountLearningPathRepository>();
        services.AddScoped<ICourseLearningPathRepository, CourseLearningPathRepository>();
        services.AddScoped<ILearningPathRepository, LearningPathRepository>();
        services.AddScoped<ICourseCategoryRepository, CourseCategoryRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IAccountCourseRepository, AccountCourseRepository>();
        services.AddScoped<ILessonRepository, LessonRepository>();
        services.AddScoped<IAccountLessonRepository, AccountLessonRepository>();
        services.AddScoped<IRecourseStepRepository, RecourseStepRepository>();
        services.AddScoped<IRecourseRepository, RecourseRepository>();
        services.AddScoped<IAccountRecourseRepository, AccountRecourseRepository>();
        services.AddScoped<IAccountAnnouncementRepository, AccountAnnouncementRepository>();
        services.AddScoped<ILearningPathCategoryRepository, LearningPathCategoryRepository>();
        return services;
    }
}
