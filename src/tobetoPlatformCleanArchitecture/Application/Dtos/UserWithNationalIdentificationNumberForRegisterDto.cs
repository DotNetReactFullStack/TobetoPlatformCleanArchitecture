using Core.Application.Dtos;
using System;
namespace Application.Dtos
{
    public class UserWithNationalIdentificationNumberForRegisterDto : IDto
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
        public string NationalIdentificationNumber { get; set; }

        public UserWithNationalIdentificationNumberForRegisterDto()
        {
            UserForRegisterDto = null;
            NationalIdentificationNumber = string.Empty;
        }

        public UserWithNationalIdentificationNumberForRegisterDto(UserForRegisterDto userForRegisterDto, string nationalIdentificationNumber)
        {
            UserForRegisterDto = userForRegisterDto;
            NationalIdentificationNumber = nationalIdentificationNumber;
        }
    }
}

