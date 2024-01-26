using Application.Features.ContractTypes.Constants;
using Application.Features.ContractTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ContractTypes.Constants.ContractTypesOperationClaims;

namespace Application.Features.ContractTypes.Queries.GetById;

public class GetByIdContractTypeQuery : IRequest<GetByIdContractTypeResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdContractTypeQueryHandler : IRequestHandler<GetByIdContractTypeQuery, GetByIdContractTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IContractTypeRepository _contractTypeRepository;
        private readonly ContractTypeBusinessRules _contractTypeBusinessRules;

        public GetByIdContractTypeQueryHandler(IMapper mapper, IContractTypeRepository contractTypeRepository, ContractTypeBusinessRules contractTypeBusinessRules)
        {
            _mapper = mapper;
            _contractTypeRepository = contractTypeRepository;
            _contractTypeBusinessRules = contractTypeBusinessRules;
        }

        public async Task<GetByIdContractTypeResponse> Handle(GetByIdContractTypeQuery request, CancellationToken cancellationToken)
        {
            ContractType? contractType = await _contractTypeRepository.GetAsync(predicate: ct => ct.Id == request.Id, cancellationToken: cancellationToken);
            await _contractTypeBusinessRules.ContractTypeShouldExistWhenSelected(contractType);

            GetByIdContractTypeResponse response = _mapper.Map<GetByIdContractTypeResponse>(contractType);
            return response;
        }
    }
}