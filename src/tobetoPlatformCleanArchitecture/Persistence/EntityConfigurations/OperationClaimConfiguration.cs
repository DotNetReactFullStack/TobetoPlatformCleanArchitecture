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
        #region SurveyTypes
        seeds.Add(new OperationClaim { Id = ++id, Name = "SurveyTypes.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SurveyTypes.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SurveyTypes.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SurveyTypes.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SurveyTypes.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SurveyTypes.Delete" });
        #endregion
        #region Surveys
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Delete" });
        #endregion
        #region OrganizationTypes
        seeds.Add(new OperationClaim { Id = ++id, Name = "OrganizationTypes.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "OrganizationTypes.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "OrganizationTypes.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "OrganizationTypes.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "OrganizationTypes.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "OrganizationTypes.Delete" });
        #endregion
        #region Organizations
        seeds.Add(new OperationClaim { Id = ++id, Name = "Organizations.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Organizations.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Organizations.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Organizations.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Organizations.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Organizations.Delete" });
        #endregion
        #region AnnouncementTypes
        seeds.Add(new OperationClaim { Id = ++id, Name = "AnnouncementTypes.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AnnouncementTypes.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AnnouncementTypes.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AnnouncementTypes.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AnnouncementTypes.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AnnouncementTypes.Delete" });
        #endregion
        #region Announcements
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Delete" });
        #endregion
        #region QuestionCategories
        seeds.Add(new OperationClaim { Id = ++id, Name = "QuestionCategories.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "QuestionCategories.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "QuestionCategories.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "QuestionCategories.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "QuestionCategories.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "QuestionCategories.Delete" });
        #endregion
        #region Questions
        seeds.Add(new OperationClaim { Id = ++id, Name = "Questions.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Questions.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Questions.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Questions.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Questions.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Questions.Delete" });
        #endregion
        #region Answers
        seeds.Add(new OperationClaim { Id = ++id, Name = "Answers.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Answers.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Answers.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Answers.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Answers.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Answers.Delete" });
        #endregion
        #region Exams
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Delete" });
        #endregion
        #region ExamQuestions
        seeds.Add(new OperationClaim { Id = ++id, Name = "ExamQuestions.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ExamQuestions.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ExamQuestions.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ExamQuestions.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ExamQuestions.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ExamQuestions.Delete" });
        #endregion
        #region ClassroomExams
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassroomExams.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassroomExams.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassroomExams.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassroomExams.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassroomExams.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassroomExams.Delete" });
        #endregion
        #region AccountExamResults
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountExamResults.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountExamResults.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountExamResults.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountExamResults.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountExamResults.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountExamResults.Delete" });
        #endregion
        #region Classrooms
        seeds.Add(new OperationClaim { Id = ++id, Name = "Classrooms.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Classrooms.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Classrooms.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Classrooms.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Classrooms.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Classrooms.Delete" });
        #endregion
        #region AccountClassrooms
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountClassrooms.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountClassrooms.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountClassrooms.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountClassrooms.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountClassrooms.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountClassrooms.Delete" });
        #endregion
        #region AccountLearningPaths
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountLearningPaths.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountLearningPaths.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountLearningPaths.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountLearningPaths.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountLearningPaths.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountLearningPaths.Delete" });
        #endregion
        #region CourseLearningPaths
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseLearningPaths.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseLearningPaths.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseLearningPaths.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseLearningPaths.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseLearningPaths.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseLearningPaths.Delete" });
        #endregion
        #region LearningPaths
        seeds.Add(new OperationClaim { Id = ++id, Name = "LearningPaths.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LearningPaths.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LearningPaths.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LearningPaths.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LearningPaths.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LearningPaths.Delete" });
        #endregion
        #region CourseCategories
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseCategories.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseCategories.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseCategories.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseCategories.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseCategories.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseCategories.Delete" });
        #endregion
        #region Courses
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Delete" });
        #endregion
        #region AccountCourses
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountCourses.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountCourses.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountCourses.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountCourses.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountCourses.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountCourses.Delete" });
        #endregion
        #region Lessons
        seeds.Add(new OperationClaim { Id = ++id, Name = "Lessons.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Lessons.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Lessons.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Lessons.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Lessons.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Lessons.Delete" });
        #endregion
        #region AccountLessons
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountLessons.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountLessons.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountLessons.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountLessons.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountLessons.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountLessons.Delete" });
        #endregion
        #region RecourseSteps
        seeds.Add(new OperationClaim { Id = ++id, Name = "RecourseSteps.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RecourseSteps.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RecourseSteps.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RecourseSteps.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RecourseSteps.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "RecourseSteps.Delete" });
        #endregion
        #region Recourses
        seeds.Add(new OperationClaim { Id = ++id, Name = "Recourses.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Recourses.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Recourses.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Recourses.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Recourses.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Recourses.Delete" });
        #endregion
        #region AccountRecourses
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountRecourses.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountRecourses.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountRecourses.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountRecourses.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountRecourses.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountRecourses.Delete" });
        #endregion
        #region AccountAnnouncements
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountAnnouncements.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountAnnouncements.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountAnnouncements.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountAnnouncements.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountAnnouncements.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AccountAnnouncements.Delete" });
        #endregion
        return seeds;
    }
}
