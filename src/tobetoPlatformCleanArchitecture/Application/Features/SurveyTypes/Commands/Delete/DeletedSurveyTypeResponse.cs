using Core.Application.Responses;

namespace Application.Features.SurveyTypes.Commands.Delete;

public class DeletedSurveyTypeResponse : IResponse
{
    public int Id { get; set; }
}