using Application.Features.AccountCollegeMetadatas.Constants;
using Application.Features.AccountCollegeMetadatas.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AccountCollegeMetadatas.Constants.AccountCollegeMetadatasOperationClaims;

namespace Application.Features.AccountCollegeMetadatas.Queries.GetById;

public class GetByIdAccountCollegeMetadataQuery : IRequest<GetByIdAccountCollegeMetadataResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdAccountCollegeMetadataQueryHandler : IRequestHandler<GetByIdAccountCollegeMetadataQuery, GetByIdAccountCollegeMetadataResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountCollegeMetadataRepository _accountCollegeMetadataRepository;
        private readonly AccountCollegeMetadataBusinessRules _accountCollegeMetadataBusinessRules;

        public GetByIdAccountCollegeMetadataQueryHandler(IMapper mapper, IAccountCollegeMetadataRepository accountCollegeMetadataRepository, AccountCollegeMetadataBusinessRules accountCollegeMetadataBusinessRules)
        {
            _mapper = mapper;
            _accountCollegeMetadataRepository = accountCollegeMetadataRepository;
            _accountCollegeMetadataBusinessRules = accountCollegeMetadataBusinessRules;
        }

        public async Task<GetByIdAccountCollegeMetadataResponse> Handle(GetByIdAccountCollegeMetadataQuery request, CancellationToken cancellationToken)
        {
            AccountCollegeMetadata? accountCollegeMetadata = await _accountCollegeMetadataRepository.GetAsync(predicate: acm => acm.Id == request.Id, cancellationToken: cancellationToken);
            await _accountCollegeMetadataBusinessRules.AccountCollegeMetadataShouldExistWhenSelected(accountCollegeMetadata);

            GetByIdAccountCollegeMetadataResponse response = _mapper.Map<GetByIdAccountCollegeMetadataResponse>(accountCollegeMetadata);
            return response;
        }
    }
}