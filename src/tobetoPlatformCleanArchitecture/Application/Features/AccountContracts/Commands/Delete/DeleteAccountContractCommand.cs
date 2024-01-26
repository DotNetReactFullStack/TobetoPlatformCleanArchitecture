using Application.Features.AccountContracts.Constants;
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

namespace Application.Features.AccountContracts.Commands.Delete;

public class DeleteAccountContractCommand : IRequest<DeletedAccountContractResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountContractsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountContracts";

    public class DeleteAccountContractCommandHandler : IRequestHandler<DeleteAccountContractCommand, DeletedAccountContractResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountContractRepository _accountContractRepository;
        private readonly AccountContractBusinessRules _accountContractBusinessRules;

        public DeleteAccountContractCommandHandler(IMapper mapper, IAccountContractRepository accountContractRepository,
                                         AccountContractBusinessRules accountContractBusinessRules)
        {
            _mapper = mapper;
            _accountContractRepository = accountContractRepository;
            _accountContractBusinessRules = accountContractBusinessRules;
        }

        public async Task<DeletedAccountContractResponse> Handle(DeleteAccountContractCommand request, CancellationToken cancellationToken)
        {
            AccountContract? accountContract = await _accountContractRepository.GetAsync(predicate: ac => ac.Id == request.Id, cancellationToken: cancellationToken);
            await _accountContractBusinessRules.AccountContractShouldExistWhenSelected(accountContract);

            await _accountContractRepository.DeleteAsync(accountContract!);

            DeletedAccountContractResponse response = _mapper.Map<DeletedAccountContractResponse>(accountContract);
            return response;
        }
    }
}