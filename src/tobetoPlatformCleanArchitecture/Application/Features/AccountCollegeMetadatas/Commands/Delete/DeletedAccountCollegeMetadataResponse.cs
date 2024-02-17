using Core.Application.Responses;

namespace Application.Features.AccountCollegeMetadatas.Commands.Delete;

public class DeletedAccountCollegeMetadataResponse : IResponse
{
    public int Id { get; set; }
}