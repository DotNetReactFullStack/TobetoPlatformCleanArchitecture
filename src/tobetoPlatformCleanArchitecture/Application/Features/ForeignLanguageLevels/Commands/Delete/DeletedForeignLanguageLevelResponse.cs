using Core.Application.Responses;

namespace Application.Features.ForeignLanguageLevels.Commands.Delete;

public class DeletedForeignLanguageLevelResponse : IResponse
{
    public int Id { get; set; }
}