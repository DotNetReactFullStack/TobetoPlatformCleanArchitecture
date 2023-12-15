using Core.Application.Responses;
using Core.Security.Entities;

namespace Application.Features.Accounts.Commands.Create;

public class CreatedAccountResponse : IResponse
{
    public Guid Id { get; set; }
    public int AddressId { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string? ProfilePhotoPath { get; set; }
    public bool IsActive { get; set; }
    public User? User { get; set; }
}