using Core.Application.Responses;

namespace Application.Features.SurveyTypes.Commands.Create;

public class CreatedSurveyTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
}