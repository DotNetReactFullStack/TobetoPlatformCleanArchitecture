using Core.Application.Dtos;

namespace Application.Features.AccountSocialMediaPlatforms.Queries.GetList;

public class GetListAccountSocialMediaPlatformListItemDto : IDto
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int SocialMediaPlatformId { get; set; }
    public int Priority { get; set; }
    public string Link { get; set; }
}