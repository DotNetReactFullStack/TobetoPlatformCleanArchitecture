using Core.Application.Responses;

namespace Application.Features.ForeignLanguages.Commands.Update;

public class UpdatedForeignLanguageResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
}