using Core.Application.Responses;
using System;
namespace Application.Features.Accounts.Queries.GetByUserId
{
    public class GetByUserIdAccountResponse : IResponse
    {
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
    }
}

