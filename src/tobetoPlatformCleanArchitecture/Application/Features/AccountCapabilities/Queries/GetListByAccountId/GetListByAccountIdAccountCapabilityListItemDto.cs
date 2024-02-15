using Core.Application.Dtos;
using System;
namespace Application.Features.AccountCapabilities.Queries.GetListByAccountId
{
    public class GetListByAccountIdAccountCapabilityListItemDto : IDto
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int CapabilityId { get; set; }
        public int Priority { get; set; }
    }
}

