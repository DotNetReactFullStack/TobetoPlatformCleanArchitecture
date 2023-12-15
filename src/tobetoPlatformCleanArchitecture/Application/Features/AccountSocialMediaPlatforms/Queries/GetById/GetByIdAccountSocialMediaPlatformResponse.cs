using Core.Application.Responses;

namespace Application.Features.AccountSocialMediaPlatforms.Queries.GetById;

public class GetByIdAccountSocialMediaPlatformResponse : IResponse
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int SocialMediaPlatformId { get; set; }
    public int Priority { get; set; }
    public string Link { get; set; }
}