using Core.Application.Responses;

namespace Application.Features.AccountSocialMediaPlatforms.Commands.Update;

public class UpdatedAccountSocialMediaPlatformResponse : IResponse
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int SocialMediaPlatformId { get; set; }
    public int Priority { get; set; }
    public string Link { get; set; }
}