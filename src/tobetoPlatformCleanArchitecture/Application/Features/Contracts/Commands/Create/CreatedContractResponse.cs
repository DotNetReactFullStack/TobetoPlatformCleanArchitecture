using Core.Application.Responses;

namespace Application.Features.Contracts.Commands.Create;

public class CreatedContractResponse : IResponse
{
    public int Id { get; set; }
    public int ContractTypeId { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public bool IsActive { get; set; }
}