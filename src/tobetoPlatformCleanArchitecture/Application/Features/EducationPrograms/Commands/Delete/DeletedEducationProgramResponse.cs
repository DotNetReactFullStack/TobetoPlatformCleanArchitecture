using Core.Application.Responses;

namespace Application.Features.EducationPrograms.Commands.Delete;

public class DeletedEducationProgramResponse : IResponse
{
    public int Id { get; set; }
}