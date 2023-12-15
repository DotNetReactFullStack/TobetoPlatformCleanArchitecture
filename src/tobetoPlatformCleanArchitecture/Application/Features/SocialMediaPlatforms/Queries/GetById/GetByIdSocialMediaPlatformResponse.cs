using Core.Application.Responses;

namespace Application.Features.SocialMediaPlatforms.Queries.GetById;

public class GetByIdSocialMediaPlatformResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string IconPath { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
}