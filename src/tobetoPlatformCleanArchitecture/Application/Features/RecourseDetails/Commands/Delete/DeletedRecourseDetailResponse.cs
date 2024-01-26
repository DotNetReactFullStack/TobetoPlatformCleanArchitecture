using Core.Application.Responses;

namespace Application.Features.RecourseDetails.Commands.Delete;

public class DeletedRecourseDetailResponse : IResponse
{
    public int Id { get; set; }
}