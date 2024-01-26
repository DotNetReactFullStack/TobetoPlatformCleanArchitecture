using Core.Application.Responses;

namespace Application.Features.Contracts.Commands.Update;

public class UpdatedContractResponse : IResponse
{
    public int Id { get; set; }
    public int ContractTypeId { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public bool IsActive { get; set; }
}