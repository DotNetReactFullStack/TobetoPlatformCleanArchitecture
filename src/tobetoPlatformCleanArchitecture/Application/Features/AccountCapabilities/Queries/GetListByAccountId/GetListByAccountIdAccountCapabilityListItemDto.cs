using Core.Application.Dtos;
using System;
namespace Application.Features.AccountCapabilities.Queries.GetListByAccountId
{
    public class GetListByAccountIdAccountCapabilityListItemDto : IDto
    {
        public int Id { get; set; }
        public string CapabilityName { get; set; }
    }
}

