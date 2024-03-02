using Application.Dtos;
using Application.Features.Accounts.Rules;
using Application.Features.Auth.Constants;
using Application.Features.Auth.Rules;
using Application.Services.Accounts;
using Application.Services.Addresses;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Application.Services.UserOperationClaims;
using AutoMapper;
using Core.Application.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Entities;
using MediatR;
using Microsoft.Identity.Client;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommand : IRequest<RegisteredResponse>
{
    public UserWithNationalIdentificationNumberForRegisterDto UserWithNationalIdentificationNumberForRegisterDto { get; set; }
    public string IpAddress { get; set; }

    public RegisterCommand()
    {
        UserWithNationalIdentificationNumberForRegisterDto = null!;
        IpAddress = string.Empty;
    }

    public RegisterCommand(UserWithNationalIdentificationNumberForRegisterDto userWithNationalIdentificationNumberForRegisterDto, string ipAddress)
    {
        UserWithNationalIdentificationNumberForRegisterDto = userWithNationalIdentificationNumberForRegisterDto;
        IpAddress = ipAddress;
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;

        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IAccountsService _accountsService;
        private readonly AccountBusinessRules _accountBusinessRules;
        private readonly IAddressesService _addressesService;


        public RegisterCommandHandler(IUserRepository userRepository, IAuthService authService, AuthBusinessRules authBusinessRules, IUserOperationClaimService userOperationClaimService, IAccountsService accountsService, AccountBusinessRules accountBusinessRules, IAddressesService addressesService)
        {
            _userRepository = userRepository;
            _authService = authService;
            _authBusinessRules = authBusinessRules;

            _userOperationClaimService = userOperationClaimService;
            _accountsService = accountsService;
            _accountBusinessRules = accountBusinessRules;
            _addressesService = addressesService;
        }

        public async Task<RegisteredResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {

            _accountBusinessRules.NationalIdentificationNumberMustBeUnique(new Account(nationalIdentificationNumber:request.UserWithNationalIdentificationNumberForRegisterDto.NationalIdentificationNumber));

            await _authBusinessRules.UserEmailShouldBeNotExists(request.UserWithNationalIdentificationNumberForRegisterDto.UserForRegisterDto.Email);

            HashingHelper.CreatePasswordHash(
                request
                .UserWithNationalIdentificationNumberForRegisterDto
                .UserForRegisterDto.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            User newUser =
                new()
                {
                    Email = request
                    .UserWithNationalIdentificationNumberForRegisterDto
                    .UserForRegisterDto.Email,
                    FirstName = request
                    .UserWithNationalIdentificationNumberForRegisterDto
                    .UserForRegisterDto.FirstName,
                    LastName = request
                    .UserWithNationalIdentificationNumberForRegisterDto
                    .UserForRegisterDto.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true
                };
            User createdUser = await _userRepository.AddAsync(newUser);

            // Refactor
            UserOperationClaim defaultUserOperationClaim = new(userId: createdUser.Id, operationClaimId: AuthOperationClaims.DefaultOperationClaimIdForEachRegistration);
            UserOperationClaim createdDefaultUserOperationClaim = await _userOperationClaimService.AddAsync(defaultUserOperationClaim);

            // Refactor
            Account account = new(
                userId: createdUser.Id,
                nationalIdentificationNumber: request
                .UserWithNationalIdentificationNumberForRegisterDto.NationalIdentificationNumber,
                aboutMe: AccountsFieldConstants.AboutMe,
                birthDate: new DateTime(),
                phoneNumber: AccountsFieldConstants.PhoneNumber,
                profileLinkUrl: AccountsFieldConstants.ProfileLinkUrl + createdUser.Id,
                shareProfile: AccountsFieldConstants.ShareProfile,
                isActive: AccountsFieldConstants.IsActive
                );

            Account createdAccount = await _accountsService.AddAsync(account);

            Address address = new(                
                accountId: createdAccount.Id,
                countryId: AddressConstants.DefaultCountryId,
                cityId: AddressConstants.DefaultCityId,
                districtId: AddressConstants.DefaultDistrictId,
                addressDetail: AddressConstants.DefaultAddressDetail
                );

            await _addressesService.AddAsync(address);

            AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);

            Core.Security.Entities.RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);
            Core.Security.Entities.RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

            RegisteredResponse registeredResponse = new() { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
            return registeredResponse;
        }
    }
}

