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

namespace Application.Features.AccountForeignLanguageMetadatas.Commands.Update;

public class UpdateAccountForeignLanguageMetadataCommand : IRequest<UpdatedAccountForeignLanguageMetadataResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int ForeignLanguageId { get; set; }
    public int ForeignLanguageLevelId { get; set; }
    public int Priority { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountForeignLanguageMetadatasOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountForeignLanguageMetadatas";

    public class UpdateAccountForeignLanguageMetadataCommandHandler : IRequestHandler<UpdateAccountForeignLanguageMetadataCommand, UpdatedAccountForeignLanguageMetadataResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountForeignLanguageMetadataRepository _accountForeignLanguageMetadataRepository;
        private readonly AccountForeignLanguageMetadataBusinessRules _accountForeignLanguageMetadataBusinessRules;

        public UpdateAccountForeignLanguageMetadataCommandHandler(IMapper mapper, IAccountForeignLanguageMetadataRepository accountForeignLanguageMetadataRepository,
                                         AccountForeignLanguageMetadataBusinessRules accountForeignLanguageMetadataBusinessRules)
        {
            _mapper = mapper;
            _accountForeignLanguageMetadataRepository = accountForeignLanguageMetadataRepository;
            _accountForeignLanguageMetadataBusinessRules = accountForeignLanguageMetadataBusinessRules;
        }

        public async Task<UpdatedAccountForeignLanguageMetadataResponse> Handle(UpdateAccountForeignLanguageMetadataCommand request, CancellationToken cancellationToken)
        {
            AccountForeignLanguageMetadata? accountForeignLanguageMetadata = await _accountForeignLanguageMetadataRepository.GetAsync(predicate: aflm => aflm.Id == request.Id, cancellationToken: cancellationToken);
            await _accountForeignLanguageMetadataBusinessRules.AccountForeignLanguageMetadataShouldExistWhenSelected(accountForeignLanguageMetadata);
            accountForeignLanguageMetadata = _mapper.Map(request, accountForeignLanguageMetadata);

            await _accountForeignLanguageMetadataRepository.UpdateAsync(accountForeignLanguageMetadata!);

            UpdatedAccountForeignLanguageMetadataResponse response = _mapper.Map<UpdatedAccountForeignLanguageMetadataResponse>(accountForeignLanguageMetadata);
            return response;
        }
    }
}