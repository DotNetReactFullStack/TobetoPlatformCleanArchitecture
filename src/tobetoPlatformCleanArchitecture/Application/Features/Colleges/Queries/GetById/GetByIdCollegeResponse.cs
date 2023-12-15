using Core.Application.Responses;

namespace Application.Features.Colleges.Queries.GetById;

public class GetByIdCollegeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Visibility { get; set; }
}