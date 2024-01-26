using Core.Application.Responses;

namespace Application.Features.ContractTypes.Commands.Update;

public class UpdatedContractTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}