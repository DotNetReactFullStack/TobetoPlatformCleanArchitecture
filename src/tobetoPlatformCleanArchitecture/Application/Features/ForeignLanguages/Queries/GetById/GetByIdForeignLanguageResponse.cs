using Core.Application.Responses;

namespace Application.Features.ForeignLanguages.Queries.GetById;

public class GetByIdForeignLanguageResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
}