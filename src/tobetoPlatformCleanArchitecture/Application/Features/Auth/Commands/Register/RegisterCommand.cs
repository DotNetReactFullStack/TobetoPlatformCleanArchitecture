using Application.Features.Auth.Constants;
using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Entities;
using MediatR;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommand : IRequest<RegisteredResponse>
{
    public UserForRegisterDto UserForRegisterDto { get; set; }
    public string IpAddress { get; set; }

    public RegisterCommand()
    {
        UserForRegisterDto = null!;
        IpAddress = string.Empty;
    }

    public RegisterCommand(UserForRegisterDto userForRegisterDto, string ipAddress)
    {
        UserForRegisterDto = userForRegisterDto;
        IpAddress = ipAddress;
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;

        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IAccountRepository _accountRepository;


        public RegisterCommandHandler(IUserRepository userRepository, IAuthService authService, AuthBusinessRules authBusinessRules, IUserOperationClaimRepository userOperationClaimRepository, IAccountRepository accountRepository)
        {
            _userRepository = userRepository;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
            _userOperationClaimRepository = userOperationClaimRepository;
            _accountRepository = accountRepository;
        }

        public async Task<RegisteredResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.UserEmailShouldBeNotExists(request.UserForRegisterDto.Email);

            HashingHelper.CreatePasswordHash(
                request.UserForRegisterDto.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            User newUser =
                new()
                {
                    Email = request.UserForRegisterDto.Email,
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true
                };
            User createdUser = await _userRepository.AddAsync(newUser);

            // Refactor
            // Add default operation claim id for each registration
            UserOperationClaim defaultUserOperationClaim = new(userId: createdUser.Id, operationClaimId: AuthOperationClaims.DefaultOperationClaimIdForEachRegistration);
            UserOperationClaim createdDefaultUserOperationClaim = await _userOperationClaimRepository.AddAsync(defaultUserOperationClaim);

            // Refactor
            // Create an account for each registration
            Account account = new(
                userId: createdUser.Id,
                nationalIdentificationNumber: AccountsFieldConstants.NationalIdentificationNumber,
                aboutMe: AccountsFieldConstants.AboutMe,
                birthDate: new DateTime(),
                phoneNumber: AccountsFieldConstants.PhoneNumber,
                profileLinkUrl: AccountsFieldConstants.ProfileLinkUrl + createdUser.Id,
                shareProfile: AccountsFieldConstants.ShareProfile,
                isActive: AccountsFieldConstants.IsActive
                );
            await _accountRepository.AddAsync(account);

            AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);

            Core.Security.Entities.RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);
            Core.Security.Entities.RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

            RegisteredResponse registeredResponse = new() { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
            return registeredResponse;
        }
    }
}
