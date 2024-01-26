using Core.Application.Responses;

namespace Application.Features.AccountRecourseDetails.Commands.Update;

public class UpdatedAccountRecourseDetailResponse : IResponse
{
    public int Id { get; set; }
    public int AccountRecourseId { get; set; }
    public int RecourseDetailStepId { get; set; }
    public int RecourseDetailId { get; set; }
}