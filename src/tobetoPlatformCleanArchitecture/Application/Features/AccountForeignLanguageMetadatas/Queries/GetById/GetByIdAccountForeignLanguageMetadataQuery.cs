using Application.Features.AccountForeignLanguageMetadatas.Constants;
using Application.Features.AccountForeignLanguageMetadatas.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AccountForeignLanguageMetadatas.Constants.AccountForeignLanguageMetadatasOperationClaims;

namespace Application.Features.AccountForeignLanguageMetadatas.Queries.GetById;

public class GetByIdAccountForeignLanguageMetadataQuery : IRequest<GetByIdAccountForeignLanguageMetadataResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdAccountForeignLanguageMetadataQueryHandler : IRequestHandler<GetByIdAccountForeignLanguageMetadataQuery, GetByIdAccountForeignLanguageMetadataResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountForeignLanguageMetadataRepository _accountForeignLanguageMetadataRepository;
        private readonly AccountForeignLanguageMetadataBusinessRules _accountForeignLanguageMetadataBusinessRules;

        public GetByIdAccountForeignLanguageMetadataQueryHandler(IMapper mapper, IAccountForeignLanguageMetadataRepository accountForeignLanguageMetadataRepository, AccountForeignLanguageMetadataBusinessRules accountForeignLanguageMetadataBusinessRules)
        {
            _mapper = mapper;
            _accountForeignLanguageMetadataRepository = accountForeignLanguageMetadataRepository;
            _accountForeignLanguageMetadataBusinessRules = accountForeignLanguageMetadataBusinessRules;
        }

        public async Task<GetByIdAccountForeignLanguageMetadataResponse> Handle(GetByIdAccountForeignLanguageMetadataQuery request, CancellationToken cancellationToken)
        {
            AccountForeignLanguageMetadata? accountForeignLanguageMetadata = await _accountForeignLanguageMetadataRepository.GetAsync(predicate: aflm => aflm.Id == request.Id, cancellationToken: cancellationToken);
            await _accountForeignLanguageMetadataBusinessRules.AccountForeignLanguageMetadataShouldExistWhenSelected(accountForeignLanguageMetadata);

            GetByIdAccountForeignLanguageMetadataResponse response = _mapper.Map<GetByIdAccountForeignLanguageMetadataResponse>(accountForeignLanguageMetadata);
            return response;
        }
    }
}