using Core.Application.Responses;

namespace Application.Features.SocialMediaPlatforms.Commands.Update;

public class UpdatedSocialMediaPlatformResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string IconPath { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
}