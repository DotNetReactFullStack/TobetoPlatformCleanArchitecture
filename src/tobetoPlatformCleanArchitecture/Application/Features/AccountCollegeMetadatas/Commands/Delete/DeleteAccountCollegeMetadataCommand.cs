using Application.Features.AccountCollegeMetadatas.Constants;
using Application.Features.AccountCollegeMetadatas.Constants;
using Application.Features.AccountCollegeMetadatas.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.AccountCollegeMetadatas.Constants.AccountCollegeMetadatasOperationClaims;
using Application.Features.OperationClaims.Constants;

namespace Application.Features.AccountCollegeMetadatas.Commands.Delete;

public class DeleteAccountCollegeMetadataCommand : IRequest<DeletedAccountCollegeMetadataResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountCollegeMetadatasOperationClaims.Delete, GeneralOperationClaims.Student };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountCollegeMetadatas";

    public class DeleteAccountCollegeMetadataCommandHandler : IRequestHandler<DeleteAccountCollegeMetadataCommand, DeletedAccountCollegeMetadataResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountCollegeMetadataRepository _accountCollegeMetadataRepository;
        private readonly AccountCollegeMetadataBusinessRules _accountCollegeMetadataBusinessRules;

        public DeleteAccountCollegeMetadataCommandHandler(IMapper mapper, IAccountCollegeMetadataRepository accountCollegeMetadataRepository,
                                         AccountCollegeMetadataBusinessRules accountCollegeMetadataBusinessRules)
        {
            _mapper = mapper;
            _accountCollegeMetadataRepository = accountCollegeMetadataRepository;
            _accountCollegeMetadataBusinessRules = accountCollegeMetadataBusinessRules;
        }

        public async Task<DeletedAccountCollegeMetadataResponse> Handle(DeleteAccountCollegeMetadataCommand request, CancellationToken cancellationToken)
        {
            AccountCollegeMetadata? accountCollegeMetadata = await _accountCollegeMetadataRepository.GetAsync(predicate: acm => acm.Id == request.Id, cancellationToken: cancellationToken);
            await _accountCollegeMetadataBusinessRules.AccountCollegeMetadataShouldExistWhenSelected(accountCollegeMetadata);

            await _accountCollegeMetadataRepository.DeleteAsync(accountCollegeMetadata!);

            DeletedAccountCollegeMetadataResponse response = _mapper.Map<DeletedAccountCollegeMetadataResponse>(accountCollegeMetadata);
            return response;
        }
    }
}