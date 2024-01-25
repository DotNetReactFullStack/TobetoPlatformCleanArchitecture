using Core.Application.Responses;

namespace Application.Features.AccountRecourseDetails.Queries.GetById;

public class GetByIdAccountRecourseDetailResponse : IResponse
{
    public int Id { get; set; }
    public int AccountRecourseId { get; set; }
    public int RecourseDetailStepId { get; set; }
    public int RecourseDetailId { get; set; }
}