using Application.Features.AccountForeignLanguageMetadatas.Constants;
using Application.Features.AccountForeignLanguageMetadatas.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.AccountForeignLanguageMetadatas.Constants.AccountForeignLanguageMetadatasOperationClaims;

namespace Application.Features.AccountForeignLanguageMetadatas.Commands.Create;

public class CreateAccountForeignLanguageMetadataCommand : IRequest<CreatedAccountForeignLanguageMetadataResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int AccountId { get; set; }
    public int ForeignLanguageId { get; set; }
    public int ForeignLanguageLevelId { get; set; }
    public int Priority { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountForeignLanguageMetadatasOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountForeignLanguageMetadatas";

    public class CreateAccountForeignLanguageMetadataCommandHandler : IRequestHandler<CreateAccountForeignLanguageMetadataCommand, CreatedAccountForeignLanguageMetadataResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountForeignLanguageMetadataRepository _accountForeignLanguageMetadataRepository;
        private readonly AccountForeignLanguageMetadataBusinessRules _accountForeignLanguageMetadataBusinessRules;

        public CreateAccountForeignLanguageMetadataCommandHandler(IMapper mapper, IAccountForeignLanguageMetadataRepository accountForeignLanguageMetadataRepository,
                                         AccountForeignLanguageMetadataBusinessRules accountForeignLanguageMetadataBusinessRules)
        {
            _mapper = mapper;
            _accountForeignLanguageMetadataRepository = accountForeignLanguageMetadataRepository;
            _accountForeignLanguageMetadataBusinessRules = accountForeignLanguageMetadataBusinessRules;
        }

        public async Task<CreatedAccountForeignLanguageMetadataResponse> Handle(CreateAccountForeignLanguageMetadataCommand request, CancellationToken cancellationToken)
        {
            AccountForeignLanguageMetadata accountForeignLanguageMetadata = _mapper.Map<AccountForeignLanguageMetadata>(request);

            await _accountForeignLanguageMetadataRepository.AddAsync(accountForeignLanguageMetadata);

            CreatedAccountForeignLanguageMetadataResponse response = _mapper.Map<CreatedAccountForeignLanguageMetadataResponse>(accountForeignLanguageMetadata);
            return response;
        }
    }
}