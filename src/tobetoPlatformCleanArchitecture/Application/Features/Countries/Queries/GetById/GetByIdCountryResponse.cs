using Core.Application.Responses;

namespace Application.Features.Countries.Queries.GetById;

public class GetByIdCountryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
}