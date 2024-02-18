using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AccountSocialMediaPlatforms.Queries.GetListByAccountId;
public class GetListByAccountIdAccountSocialMediaPlatformsItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string IconPath { get; set; }
    
}
