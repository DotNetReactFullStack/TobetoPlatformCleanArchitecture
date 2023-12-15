using Core.Application.Responses;

namespace Application.Features.Cities.Commands.Delete;

public class DeletedCityResponse : IResponse
{
    public int Id { get; set; }
}