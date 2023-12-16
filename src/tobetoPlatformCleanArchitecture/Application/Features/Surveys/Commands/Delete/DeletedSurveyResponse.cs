using Core.Application.Responses;

namespace Application.Features.Surveys.Commands.Delete;

public class DeletedSurveyResponse : IResponse
{
    public int Id { get; set; }
}