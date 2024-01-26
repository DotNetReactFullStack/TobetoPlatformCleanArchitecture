using Core.Application.Responses;

namespace Application.Features.RecourseDetails.Commands.Create;

public class CreatedRecourseDetailResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Priority { get; set; }
    public bool Visibility { get; set; }
}