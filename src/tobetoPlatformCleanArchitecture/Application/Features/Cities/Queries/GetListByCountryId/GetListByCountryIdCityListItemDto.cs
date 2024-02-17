using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Queries.GetListByCountryId;
public class GetListByCountryIdCityListItemDto : IDto
{
    public int Id { get; set; }
    public int CountryId { get; set; }
    public string Name { get; set; }
    public int Visibility { get; set; }
}
