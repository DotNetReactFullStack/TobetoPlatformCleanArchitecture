using Application.Features.Contracts.Constants;
using Application.Features.Contracts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Contracts.Constants.ContractsOperationClaims;

namespace Application.Features.Contracts.Queries.GetById;

public class GetByIdContractQuery : IRequest<GetByIdContractResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdContractQueryHandler : IRequestHandler<GetByIdContractQuery, GetByIdContractResponse>
    {
        private readonly IMapper _mapper;
        private readonly IContractRepository _contractRepository;
        private readonly ContractBusinessRules _contractBusinessRules;

        public GetByIdContractQueryHandler(IMapper mapper, IContractRepository contractRepository, ContractBusinessRules contractBusinessRules)
        {
            _mapper = mapper;
            _contractRepository = contractRepository;
            _contractBusinessRules = contractBusinessRules;
        }

        public async Task<GetByIdContractResponse> Handle(GetByIdContractQuery request, CancellationToken cancellationToken)
        {
            Contract? contract = await _contractRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _contractBusinessRules.ContractShouldExistWhenSelected(contract);

            GetByIdContractResponse response = _mapper.Map<GetByIdContractResponse>(contract);
            return response;
        }
    }
}