using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Districts.Queries.GetListByCityId;
public class GetListByCityIdDistrictListItemDto
{
    public int Id { get; set; }
    public int City { get; set; }
    public string Name { get; set; }
    public int Visibility { get; set; }
}
