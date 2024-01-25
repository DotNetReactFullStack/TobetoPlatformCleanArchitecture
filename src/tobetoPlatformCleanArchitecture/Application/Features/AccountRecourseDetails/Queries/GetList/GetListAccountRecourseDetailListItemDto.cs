using Core.Application.Dtos;

namespace Application.Features.AccountRecourseDetails.Queries.GetList;

public class GetListAccountRecourseDetailListItemDto : IDto
{
    public int Id { get; set; }
    public int AccountRecourseId { get; set; }
    public int RecourseDetailStepId { get; set; }
    public int RecourseDetailId { get; set; }
}