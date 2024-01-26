using Core.Application.Responses;

namespace Application.Features.ContractTypes.Queries.GetById;

public class GetByIdContractTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}