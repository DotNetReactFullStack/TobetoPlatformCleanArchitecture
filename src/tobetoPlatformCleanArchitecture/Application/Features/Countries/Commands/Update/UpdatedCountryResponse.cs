using Core.Application.Responses;

namespace Application.Features.Countries.Commands.Update;

public class UpdatedCountryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
}