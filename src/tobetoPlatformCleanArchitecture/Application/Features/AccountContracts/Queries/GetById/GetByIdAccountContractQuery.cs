using Application.Features.AccountContracts.Constants;
using Application.Features.AccountContracts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AccountContracts.Constants.AccountContractsOperationClaims;

namespace Application.Features.AccountContracts.Queries.GetById;

public class GetByIdAccountContractQuery : IRequest<GetByIdAccountContractResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdAccountContractQueryHandler : IRequestHandler<GetByIdAccountContractQuery, GetByIdAccountContractResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountContractRepository _accountContractRepository;
        private readonly AccountContractBusinessRules _accountContractBusinessRules;

        public GetByIdAccountContractQueryHandler(IMapper mapper, IAccountContractRepository accountContractRepository, AccountContractBusinessRules accountContractBusinessRules)
        {
            _mapper = mapper;
            _accountContractRepository = accountContractRepository;
            _accountContractBusinessRules = accountContractBusinessRules;
        }

        public async Task<GetByIdAccountContractResponse> Handle(GetByIdAccountContractQuery request, CancellationToken cancellationToken)
        {
            AccountContract? accountContract = await _accountContractRepository.GetAsync(predicate: ac => ac.Id == request.Id, cancellationToken: cancellationToken);
            await _accountContractBusinessRules.AccountContractShouldExistWhenSelected(accountContract);

            GetByIdAccountContractResponse response = _mapper.Map<GetByIdAccountContractResponse>(accountContract);
            return response;
        }
    }
}