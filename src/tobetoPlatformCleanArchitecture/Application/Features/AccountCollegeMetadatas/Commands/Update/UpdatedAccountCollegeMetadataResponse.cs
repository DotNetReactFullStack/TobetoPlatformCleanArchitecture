using Core.Application.Responses;

namespace Application.Features.AccountCollegeMetadatas.Commands.Update;

public class UpdatedAccountCollegeMetadataResponse : IResponse
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int GraduationStatusId { get; set; }
    public int CollegeId { get; set; }
    public int EducationProgramId { get; set; }
    public bool Visibility { get; set; }
    public DateTime StartingYear { get; set; }
    public DateTime? GraduationYear { get; set; }
    public bool ProgramOnGoing { get; set; }
}