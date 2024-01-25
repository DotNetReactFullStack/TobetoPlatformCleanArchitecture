using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Address : Entity<int>
{
    public int AccountId { get; set; }
    public int CountryId { get; set; }
    public int CityId { get; set; }
    public int DistrictId { get; set; }
    public string AddressDetail { get; set; }

    public virtual Account? Account { get; set; }
    public virtual Country? Country { get; set; }
    public virtual City? City { get; set; }
    public virtual District? District { get; set; }

    public Address()
    {
        
    }

    public Address(int id, int accountId, int cityId, int districtId, int countryId, string addressDetail) : this()
    {
        Id = id;
        AccountId = accountId;
        CityId = cityId;
        DistrictId = districtId;
        CountryId = countryId;
        AddressDetail = addressDetail;
    }
}
