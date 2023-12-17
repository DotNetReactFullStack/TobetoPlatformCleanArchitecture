using Core.Persistence.Repositories;
using Core.Security.Entities;
using Core.Security.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Account : Entity<Guid>
    {
        public int AddressId { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string? ProfilePhotoPath { get; set; }
        public bool IsActive { get; set; }
        
        public virtual User User { get; set; }
        public virtual Address? Address { get; set; }

        public virtual ICollection<AccountCapability> AccountCapabilities { get; set; }
        public virtual ICollection<AccountCertificate> AccountCertificates { get; set; }
        public virtual ICollection<AccountSocialMediaPlatform> AccountSocialMediaPlatforms { get; set; }
        public virtual ICollection<AccountCollageMetadata> AccountCollageMetadatas { get; set; }
        public virtual ICollection<AccountForeignLanguageMetadata> AccountForeignLanguageMetadatas{ get; set; }
        public virtual ICollection<AccountRecourse> AccountRecourses { get; set; }
        public virtual ICollection<AccountExamResult> AccountExamResults { get; set; }
        public virtual ICollection<AccountLearningPath> AccountLearningPaths { get; set; }
        public virtual ICollection<AccountLesson> AccountLessons { get; set; }
        public virtual ICollection<AccountClassroom> AccountClassrooms { get; set; }
        public virtual ICollection<AccountCourse> AccountCourses { get; set; } 
        //public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } 

        


        public Account()
        {
            
        }


        public Account(string firstName, string lastName, string email) :this()
        {
            User.FirstName = firstName;
            User.LastName = lastName;
            User.Email = email;
        }

        public Account(Guid id, string firstName, string lastName, string email, int addressId, DateTime birthDate, string phoneNumber, string? profilePhotoPath, bool isActive) : this()
        {
            Id = id;
            User.FirstName = firstName;
            User.LastName = lastName;
            User.Email = email;
            AddressId = addressId;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            ProfilePhotoPath = profilePhotoPath;
            IsActive = isActive;
        }
    }

}
