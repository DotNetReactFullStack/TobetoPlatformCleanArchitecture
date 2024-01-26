using Application.Features.AccountContracts.Constants;
using Application.Features.AccountContracts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.AccountContracts.Constants.AccountContractsOperationClaims;

namespace Application.Features.AccountContracts.Commands.Create;

public class CreateAccountContractCommand : IRequest<CreatedAccountContractResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int AccountId { get; set; }
    public int ContractId { get; set; }
    public bool IsAccept { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountContractsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountContracts";

    public class CreateAccountContractCommandHandler : IRequestHandler<CreateAccountContractCommand, CreatedAccountContractResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountContractRepository _accountContractRepository;
        private readonly AccountContractBusinessRules _accountContractBusinessRules;

        public CreateAccountContractCommandHandler(IMapper mapper, IAccountContractRepository accountContractRepository,
                                         AccountContractBusinessRules accountContractBusinessRules)
        {
            _mapper = mapper;
            _accountContractRepository = accountContractRepository;
            _accountContractBusinessRules = accountContractBusinessRules;
        }

        public async Task<CreatedAccountContractResponse> Handle(CreateAccountContractCommand request, CancellationToken cancellationToken)
        {
            AccountContract accountContract = _mapper.Map<AccountContract>(request);

            await _accountContractRepository.AddAsync(accountContract);

            CreatedAccountContractResponse response = _mapper.Map<CreatedAccountContractResponse>(accountContract);
            return response;
        }
    }
}