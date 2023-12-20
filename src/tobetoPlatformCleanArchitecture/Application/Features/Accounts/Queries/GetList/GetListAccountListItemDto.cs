using Core.Application.Dtos;

namespace Application.Features.Accounts.Queries.GetList;

public class GetListAccountListItemDto : IDto
{
    public int Id { get; set; }
    public int AddressId { get; set; }
    public string NationalIdentificationNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string? ProfilePhotoPath { get; set; }
    public bool IsActive { get; set; }
}