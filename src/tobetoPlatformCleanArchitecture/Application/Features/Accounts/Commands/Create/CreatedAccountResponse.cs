using Core.Application.Responses;

namespace Application.Features.Accounts.Commands.Create;

public class CreatedAccountResponse : IResponse
{
    public int Id { get; set; }
    public int AddressId { get; set; }
    public string NationalIdentificationNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string? ProfilePhotoPath { get; set; }
    public bool IsActive { get; set; }
}