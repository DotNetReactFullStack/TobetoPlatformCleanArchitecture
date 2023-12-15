using Core.Application.Responses;

namespace Application.Features.Cities.Commands.Update;

public class UpdatedCityResponse : IResponse
{
    public int Id { get; set; }
    public int CountryId { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
}