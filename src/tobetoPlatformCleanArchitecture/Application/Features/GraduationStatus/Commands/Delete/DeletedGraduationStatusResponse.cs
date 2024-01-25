using Core.Application.Responses;

namespace Application.Features.GraduationStatus.Commands.Delete;

public class DeletedGraduationStatusResponse : IResponse
{
    public int Id { get; set; }
}