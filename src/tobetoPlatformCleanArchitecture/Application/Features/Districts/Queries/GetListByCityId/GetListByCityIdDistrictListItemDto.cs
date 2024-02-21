using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Districts.Queries.GetListByCityId;
public class GetListByCityIdDistrictListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Visibility { get; set; }
}
