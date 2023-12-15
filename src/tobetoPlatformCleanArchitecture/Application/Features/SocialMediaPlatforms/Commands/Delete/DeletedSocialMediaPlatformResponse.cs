using Core.Application.Responses;

namespace Application.Features.SocialMediaPlatforms.Commands.Delete;

public class DeletedSocialMediaPlatformResponse : IResponse
{
    public int Id { get; set; }
}