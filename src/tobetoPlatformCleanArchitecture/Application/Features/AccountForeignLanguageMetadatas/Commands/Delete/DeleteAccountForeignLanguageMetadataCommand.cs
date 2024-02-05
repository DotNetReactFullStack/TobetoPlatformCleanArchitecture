using Application.Features.AccountForeignLanguageMetadatas.Constants;
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
using Application.Features.OperationClaims.Constants;

namespace Application.Features.AccountForeignLanguageMetadatas.Commands.Delete;

public class DeleteAccountForeignLanguageMetadataCommand : IRequest<DeletedAccountForeignLanguageMetadataResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountForeignLanguageMetadatasOperationClaims.Delete, GeneralOperationClaims.Student };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountForeignLanguageMetadatas";

    public class DeleteAccountForeignLanguageMetadataCommandHandler : IRequestHandler<DeleteAccountForeignLanguageMetadataCommand, DeletedAccountForeignLanguageMetadataResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountForeignLanguageMetadataRepository _accountForeignLanguageMetadataRepository;
        private readonly AccountForeignLanguageMetadataBusinessRules _accountForeignLanguageMetadataBusinessRules;

        public DeleteAccountForeignLanguageMetadataCommandHandler(IMapper mapper, IAccountForeignLanguageMetadataRepository accountForeignLanguageMetadataRepository,
                                         AccountForeignLanguageMetadataBusinessRules accountForeignLanguageMetadataBusinessRules)
        {
            _mapper = mapper;
            _accountForeignLanguageMetadataRepository = accountForeignLanguageMetadataRepository;
            _accountForeignLanguageMetadataBusinessRules = accountForeignLanguageMetadataBusinessRules;
        }

        public async Task<DeletedAccountForeignLanguageMetadataResponse> Handle(DeleteAccountForeignLanguageMetadataCommand request, CancellationToken cancellationToken)
        {
            AccountForeignLanguageMetadata? accountForeignLanguageMetadata = await _accountForeignLanguageMetadataRepository.GetAsync(predicate: aflm => aflm.Id == request.Id, cancellationToken: cancellationToken);
            await _accountForeignLanguageMetadataBusinessRules.AccountForeignLanguageMetadataShouldExistWhenSelected(accountForeignLanguageMetadata);

            await _accountForeignLanguageMetadataRepository.DeleteAsync(accountForeignLanguageMetadata!);

            DeletedAccountForeignLanguageMetadataResponse response = _mapper.Map<DeletedAccountForeignLanguageMetadataResponse>(accountForeignLanguageMetadata);
            return response;
        }
    }
}