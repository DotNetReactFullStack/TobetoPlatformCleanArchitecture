using Core.Application.Responses;

namespace Application.Features.Accounts.Queries.GetById;

public class GetByIdAccountResponse : IResponse
{
    public Guid Id { get; set; }
    public int AddressId { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string? ProfilePhotoPath { get; set; }
    public bool IsActive { get; set; }
}