using Core.Application.Dtos;

namespace Application.Features.SocialMediaPlatforms.Queries.GetList;

public class GetListSocialMediaPlatformListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string IconPath { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
}