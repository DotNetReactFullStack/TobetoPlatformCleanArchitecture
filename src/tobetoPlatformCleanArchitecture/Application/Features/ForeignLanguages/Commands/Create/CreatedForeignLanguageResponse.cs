using Core.Application.Responses;

namespace Application.Features.ForeignLanguages.Commands.Create;

public class CreatedForeignLanguageResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
}