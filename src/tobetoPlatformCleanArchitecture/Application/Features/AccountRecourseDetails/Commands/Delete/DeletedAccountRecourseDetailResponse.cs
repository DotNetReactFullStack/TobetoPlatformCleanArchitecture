using Core.Application.Responses;

namespace Application.Features.AccountRecourseDetails.Commands.Delete;

public class DeletedAccountRecourseDetailResponse : IResponse
{
    public int Id { get; set; }
}