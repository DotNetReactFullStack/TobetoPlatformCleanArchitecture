using Core.Application.Responses;

namespace Application.Features.RecourseDetails.Queries.GetById;

public class GetByIdRecourseDetailResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Priority { get; set; }
    public bool Visibility { get; set; }
}