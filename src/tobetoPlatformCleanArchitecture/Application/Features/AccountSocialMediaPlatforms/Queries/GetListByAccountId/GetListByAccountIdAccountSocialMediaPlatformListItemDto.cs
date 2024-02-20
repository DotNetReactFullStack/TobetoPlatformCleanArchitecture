using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountSocialMediaPlatforms.Queries.GetListByAccountId;
public class GetListByAccountIdAccountSocialMediaPlatformListItemDto : IDto
{
    public int Id { get; set; }
    public int SocialMediaPlatformId { get; set; }
    public string SocialMediaPlatformName { get; set; }
    public string IconPath { get; set; }
    public string Link { get; set; }
    public int Priority { get; set; }   

}
