using Core.Application.Responses;

namespace Application.Features.ForeignLanguageLevels.Commands.Update;

public class UpdatedForeignLanguageLevelResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
}