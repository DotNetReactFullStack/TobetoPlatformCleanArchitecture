using Application.Features.OperationClaims.Constants;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasMany(oc => oc.UserOperationClaims);

        builder.HasData(getSeeds());
    }

    private HashSet<OperationClaim> getSeeds()
    {
        int id = 0;
        HashSet<OperationClaim> seeds =
            new()
            {
                new OperationClaim { Id = ++id, Name = GeneralOperationClaims.Admin }
            };


        #region Accounts
        seeds.Add(new OperationClaim { Id = ++id, Name = "Accounts.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Accounts.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Accounts.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Accounts.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Accounts.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Accounts.Delete" });
        #endregion
        #region Cities
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Delete" });
        #endregion
        #region Countries
        seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Delete" });
        #endregion
        #region Addresses
        seeds.Add(new OperationClaim { Id = ++id, Name = "Addresses.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Addresses.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Addresses.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Addresses.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Addresses.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Addresses.Delete" });
        #endregion
        #region Districts
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Delete" });
        #endregion
        
        #region Capabilities
        seeds.Add(new OperationClaim { Id = ++id, Name = "Capabilities.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Capabilities.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Capabilities.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Capabilities.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Capabilities.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Capabilities.Delete" });
        #endregion
        #region AccountCapabilities
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountCapabilities.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountCapabilities.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountCapabilities.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountCapabilities.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountCapabilities.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountCapabilities.Delete" });
        #endregion
        #region ForeignLanguageLevels
        seeds.Add(new OperationClaim { Id = ++id, Name = "ForeignLanguageLevels.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ForeignLanguageLevels.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ForeignLanguageLevels.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ForeignLanguageLevels.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ForeignLanguageLevels.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ForeignLanguageLevels.Delete" });
        #endregion
        #region ForeignLanguages
        seeds.Add(new OperationClaim { Id = ++id, Name = "ForeignLanguages.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ForeignLanguages.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ForeignLanguages.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ForeignLanguages.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ForeignLanguages.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ForeignLanguages.Delete" });
        #endregion
        #region AccountForeignLanguageMetadatas
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountForeignLanguageMetadatas.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountForeignLanguageMetadatas.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountForeignLanguageMetadatas.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountForeignLanguageMetadatas.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountForeignLanguageMetadatas.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountForeignLanguageMetadatas.Delete" });
        #endregion
        #region Certificates
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Delete" });
        #endregion
        #region AccountCertificates
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountCertificates.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountCertificates.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountCertificates.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountCertificates.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountCertificates.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountCertificates.Delete" });
        #endregion
        #region SocialMediaPlatforms
        seeds.Add(new OperationClaim { Id = ++id, Name = "SocialMediaPlatforms.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SocialMediaPlatforms.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SocialMediaPlatforms.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SocialMediaPlatforms.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SocialMediaPlatforms.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SocialMediaPlatforms.Delete" });
        #endregion
        #region AccountSocialMediaPlatforms
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountSocialMediaPlatforms.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountSocialMediaPlatforms.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountSocialMediaPlatforms.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountSocialMediaPlatforms.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountSocialMediaPlatforms.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountSocialMediaPlatforms.Delete" });
        #endregion
        #region GraduationStatus
        seeds.Add(new OperationClaim { Id = ++id, Name = "GraduationStatus.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "GraduationStatus.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "GraduationStatus.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "GraduationStatus.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "GraduationStatus.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "GraduationStatus.Delete" });
        #endregion
        #region Colleges
        seeds.Add(new OperationClaim { Id = ++id, Name = "Colleges.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Colleges.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Colleges.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Colleges.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Colleges.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Colleges.Delete" });
        #endregion
        #region EducationPrograms
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationPrograms.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationPrograms.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationPrograms.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationPrograms.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationPrograms.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EducationPrograms.Delete" });
        #endregion
        #region AccountCollageMetadatas
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountCollageMetadatas.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountCollageMetadatas.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountCollageMetadatas.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountCollageMetadatas.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountCollageMetadatas.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountCollageMetadatas.Delete" });
        #endregion
        return seeds;        
    }
}
