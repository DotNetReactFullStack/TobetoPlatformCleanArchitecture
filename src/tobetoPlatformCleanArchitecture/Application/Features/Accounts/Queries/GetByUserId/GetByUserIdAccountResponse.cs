using Core.Application.Responses;
using Core.Security.Enums;
using System;
namespace Application.Features.Accounts.Queries.GetByUserId
{
    public class GetByUserIdAccountResponse : IResponse
    {
        //Account
        public int Id { get; set; }
        public int UserId { get; set; }
        public string NationalIdentificationNumber { get; set; }
        public string AboutMe { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string? ProfilePhotoPath { get; set; }
        public bool ShareProfile { get; set; }
        public string ProfileLinkUrl { get; set; }
        public bool IsActive { get; set; }

        //User
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public AuthenticatorType AuthenticatorType { get; set; }

        //refactor
        //public DateTime CreatedDate { get; set; }
        //public DateTime? UpdatedDate { get; set; }
        //public DateTime? DeletedDate { get; set; }
    }
}

