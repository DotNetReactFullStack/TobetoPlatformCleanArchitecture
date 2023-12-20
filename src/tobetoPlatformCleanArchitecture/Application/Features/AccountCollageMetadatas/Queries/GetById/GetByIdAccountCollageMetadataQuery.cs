using Application.Features.AccountCollageMetadatas.Constants;
using Application.Features.AccountCollageMetadatas.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AccountCollageMetadatas.Constants.AccountCollageMetadatasOperationClaims;

namespace Application.Features.AccountCollageMetadatas.Queries.GetById;

public class GetByIdAccountCollageMetadataQuery : IRequest<GetByIdAccountCollageMetadataResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdAccountCollageMetadataQueryHandler : IRequestHandler<GetByIdAccountCollageMetadataQuery, GetByIdAccountCollageMetadataResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountCollageMetadataRepository _accountCollageMetadataRepository;
        private readonly AccountCollageMetadataBusinessRules _accountCollageMetadataBusinessRules;

        public GetByIdAccountCollageMetadataQueryHandler(IMapper mapper, IAccountCollageMetadataRepository accountCollageMetadataRepository, AccountCollageMetadataBusinessRules accountCollageMetadataBusinessRules)
        {
            _mapper = mapper;
            _accountCollageMetadataRepository = accountCollageMetadataRepository;
            _accountCollageMetadataBusinessRules = accountCollageMetadataBusinessRules;
        }

        public async Task<GetByIdAccountCollageMetadataResponse> Handle(GetByIdAccountCollageMetadataQuery request, CancellationToken cancellationToken)
        {
            AccountCollageMetadata? accountCollageMetadata = await _accountCollageMetadataRepository.GetAsync(predicate: acm => acm.Id == request.Id, cancellationToken: cancellationToken);
            await _accountCollageMetadataBusinessRules.AccountCollageMetadataShouldExistWhenSelected(accountCollageMetadata);

            GetByIdAccountCollageMetadataResponse response = _mapper.Map<GetByIdAccountCollageMetadataResponse>(accountCollageMetadata);
            return response;
        }
    }
}