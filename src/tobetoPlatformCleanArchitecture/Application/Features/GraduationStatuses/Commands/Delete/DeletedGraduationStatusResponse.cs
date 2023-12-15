using Core.Application.Responses;

namespace Application.Features.GraduationStatuses.Commands.Delete;

public class DeletedGraduationStatusResponse : IResponse
{
    public int Id { get; set; }
}