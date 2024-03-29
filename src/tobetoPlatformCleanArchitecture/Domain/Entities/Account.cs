﻿using Core.Persistence.Repositories;
using Core.Security.Entities;
using Core.Security.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Account : Entity<int>
    {
        public int UserId { get; set; }
        public string NationalIdentificationNumber { get; set; }
        public string AboutMe { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string? ProfilePhotoPath { get; set; }
        public string ProfileLinkUrl { get; set; }
        public bool ShareProfile { get; set; }
        public bool IsActive { get; set; }

        public virtual User User { get; set; }
        public virtual Address? Address { get; set; }
        public virtual ICollection<AccountCapability> AccountCapabilities { get; set; }
        public virtual ICollection<AccountCertificate> AccountCertificates { get; set; }
        public virtual ICollection<AccountSocialMediaPlatform> AccountSocialMediaPlatforms { get; set; }
        public virtual ICollection<AccountCollegeMetadata> AccountCollegeMetadatas { get; set; }
        public virtual ICollection<AccountForeignLanguageMetadata> AccountForeignLanguageMetadatas { get; set; }
        public virtual ICollection<AccountRecourse> AccountRecourses { get; set; }
        public virtual ICollection<AccountExamResult> AccountExamResults { get; set; }
        public virtual ICollection<AccountLearningPath> AccountLearningPaths { get; set; }
        public virtual ICollection<AccountLesson> AccountLessons { get; set; }
        public virtual ICollection<AccountClassroom> AccountClassrooms { get; set; }
        public virtual ICollection<AccountCourse> AccountCourses { get; set; }
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
        public virtual ICollection<AccountAnnouncement> AccountAnnouncements { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }

        public Account()
        {
            
        }

        public Account(string nationalIdentificationNumber)
        {
            NationalIdentificationNumber = nationalIdentificationNumber;
        }

        public Account(int userId, string nationalIdentificationNumber, string aboutMe, DateTime birthDate, string phoneNumber, bool shareProfile, string profileLinkUrl, bool isActive) : this()
        {
            UserId = userId;
            NationalIdentificationNumber = nationalIdentificationNumber;
            AboutMe = aboutMe;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            ProfileLinkUrl = profileLinkUrl;
            ShareProfile = shareProfile;
            IsActive = isActive;
        }

        public Account(int id, int userId, string nationalIdentificationNumber, string aboutMe, DateTime birthDate, string phoneNumber, string? profilePhotoPath, bool shareProfile, string profileLinkUrl, bool isActive) : this()
        {
            Id = id;
            UserId = userId;
            NationalIdentificationNumber = nationalIdentificationNumber;
            AboutMe = aboutMe;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            ProfilePhotoPath = profilePhotoPath;
            ProfileLinkUrl = profileLinkUrl;
            ShareProfile = shareProfile;
            IsActive = isActive;
        }
    }

}
