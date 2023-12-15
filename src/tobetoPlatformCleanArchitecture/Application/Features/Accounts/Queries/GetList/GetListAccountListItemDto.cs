using Core.Application.Dtos;
using Core.Security.Entities;

namespace Application.Features.Accounts.Queries.GetList;

public class GetListAccountListItemDto : IDto
{
    public Guid Id { get; set; }
    public int AddressId { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string? ProfilePhotoPath { get; set; }
    public bool IsActive { get; set; }
    public User? User { get; set; }
}