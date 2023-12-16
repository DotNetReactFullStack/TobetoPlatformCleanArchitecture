using Core.Application.Responses;

namespace Application.Features.LearningPaths.Commands.Update;

public class UpdatedLearningPathResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Visibility { get; set; }
    public DateTime StartingTime { get; set; }
    public DateTime EndTime { get; set; }
}