using Application.Features.AccountCollageMetadatas.Constants;
using Application.Features.AccountCollageMetadatas.Constants;
using Application.Features.AccountCollageMetadatas.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.AccountCollageMetadatas.Constants.AccountCollageMetadatasOperationClaims;

namespace Application.Features.AccountCollageMetadatas.Commands.Delete;

public class DeleteAccountCollageMetadataCommand : IRequest<DeletedAccountCollageMetadataResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountCollageMetadatasOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountCollageMetadatas";

    public class DeleteAccountCollageMetadataCommandHandler : IRequestHandler<DeleteAccountCollageMetadataCommand, DeletedAccountCollageMetadataResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountCollageMetadataRepository _accountCollageMetadataRepository;
        private readonly AccountCollageMetadataBusinessRules _accountCollageMetadataBusinessRules;

        public DeleteAccountCollageMetadataCommandHandler(IMapper mapper, IAccountCollageMetadataRepository accountCollageMetadataRepository,
                                         AccountCollageMetadataBusinessRules accountCollageMetadataBusinessRules)
        {
            _mapper = mapper;
            _accountCollageMetadataRepository = accountCollageMetadataRepository;
            _accountCollageMetadataBusinessRules = accountCollageMetadataBusinessRules;
        }

        public async Task<DeletedAccountCollageMetadataResponse> Handle(DeleteAccountCollageMetadataCommand request, CancellationToken cancellationToken)
        {
            AccountCollageMetadata? accountCollageMetadata = await _accountCollageMetadataRepository.GetAsync(predicate: acm => acm.Id == request.Id, cancellationToken: cancellationToken);
            await _accountCollageMetadataBusinessRules.AccountCollageMetadataShouldExistWhenSelected(accountCollageMetadata);

            await _accountCollageMetadataRepository.DeleteAsync(accountCollageMetadata!);

            DeletedAccountCollageMetadataResponse response = _mapper.Map<DeletedAccountCollageMetadataResponse>(accountCollageMetadata);
            return response;
        }
    }
}