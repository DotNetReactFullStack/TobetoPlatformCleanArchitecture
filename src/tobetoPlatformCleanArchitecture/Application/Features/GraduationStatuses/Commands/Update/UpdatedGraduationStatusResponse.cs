using Core.Application.Responses;

namespace Application.Features.GraduationStatuses.Commands.Update;

public class UpdatedGraduationStatusResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
}