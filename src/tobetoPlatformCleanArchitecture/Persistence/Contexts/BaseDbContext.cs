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

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {
        Configuration = configuration;
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
