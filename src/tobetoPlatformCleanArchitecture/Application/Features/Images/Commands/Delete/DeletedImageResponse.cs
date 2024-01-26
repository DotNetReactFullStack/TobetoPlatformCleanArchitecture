using Core.Application.Responses;

namespace Application.Features.Images.Commands.Delete;

public class DeletedImageResponse : IResponse
{
    public int Id { get; set; }
}