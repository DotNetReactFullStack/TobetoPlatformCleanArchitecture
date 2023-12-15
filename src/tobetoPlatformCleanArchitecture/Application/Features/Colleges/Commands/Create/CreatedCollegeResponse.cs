using Core.Application.Responses;

namespace Application.Features.Colleges.Commands.Create;

public class CreatedCollegeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Visibility { get; set; }
}