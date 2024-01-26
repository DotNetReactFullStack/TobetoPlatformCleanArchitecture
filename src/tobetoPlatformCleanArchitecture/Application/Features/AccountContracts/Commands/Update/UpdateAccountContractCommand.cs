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

namespace Application.Features.AccountContracts.Commands.Update;

public class UpdateAccountContractCommand : IRequest<UpdatedAccountContractResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int ContractId { get; set; }
    public bool IsAccept { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountContractsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountContracts";

    public class UpdateAccountContractCommandHandler : IRequestHandler<UpdateAccountContractCommand, UpdatedAccountContractResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountContractRepository _accountContractRepository;
        private readonly AccountContractBusinessRules _accountContractBusinessRules;

        public UpdateAccountContractCommandHandler(IMapper mapper, IAccountContractRepository accountContractRepository,
                                         AccountContractBusinessRules accountContractBusinessRules)
        {
            _mapper = mapper;
            _accountContractRepository = accountContractRepository;
            _accountContractBusinessRules = accountContractBusinessRules;
        }

        public async Task<UpdatedAccountContractResponse> Handle(UpdateAccountContractCommand request, CancellationToken cancellationToken)
        {
            AccountContract? accountContract = await _accountContractRepository.GetAsync(predicate: ac => ac.Id == request.Id, cancellationToken: cancellationToken);
            await _accountContractBusinessRules.AccountContractShouldExistWhenSelected(accountContract);
            accountContract = _mapper.Map(request, accountContract);

            await _accountContractRepository.UpdateAsync(accountContract!);

            UpdatedAccountContractResponse response = _mapper.Map<UpdatedAccountContractResponse>(accountContract);
            return response;
        }
    }
}