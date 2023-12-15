using Core.Application.Responses;

namespace Application.Features.GraduationStatuses.Queries.GetById;

public class GetByIdGraduationStatusResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
}