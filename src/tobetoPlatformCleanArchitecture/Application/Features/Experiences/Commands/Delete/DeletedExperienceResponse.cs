using Core.Application.Responses;

namespace Application.Features.Experiences.Commands.Delete;

public class DeletedExperienceResponse : IResponse
{
    public int Id { get; set; }
}