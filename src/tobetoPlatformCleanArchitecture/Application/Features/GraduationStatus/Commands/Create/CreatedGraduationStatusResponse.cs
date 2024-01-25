using Core.Application.Responses;

namespace Application.Features.GraduationStatus.Commands.Create;

public class CreatedGraduationStatusResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
}