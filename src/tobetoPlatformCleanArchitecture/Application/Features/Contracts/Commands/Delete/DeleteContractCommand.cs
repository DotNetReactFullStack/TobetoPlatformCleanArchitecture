using Application.Features.Contracts.Constants;
using Application.Features.Contracts.Constants;
using Application.Features.Contracts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Contracts.Constants.ContractsOperationClaims;

namespace Application.Features.Contracts.Commands.Delete;

public class DeleteContractCommand : IRequest<DeletedContractResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ContractsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetContracts";

    public class DeleteContractCommandHandler : IRequestHandler<DeleteContractCommand, DeletedContractResponse>
    {
        private readonly IMapper _mapper;
        private readonly IContractRepository _contractRepository;
        private readonly ContractBusinessRules _contractBusinessRules;

        public DeleteContractCommandHandler(IMapper mapper, IContractRepository contractRepository,
                                         ContractBusinessRules contractBusinessRules)
        {
            _mapper = mapper;
            _contractRepository = contractRepository;
            _contractBusinessRules = contractBusinessRules;
        }

        public async Task<DeletedContractResponse> Handle(DeleteContractCommand request, CancellationToken cancellationToken)
        {
            Contract? contract = await _contractRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _contractBusinessRules.ContractShouldExistWhenSelected(contract);

            await _contractRepository.DeleteAsync(contract!);

            DeletedContractResponse response = _mapper.Map<DeletedContractResponse>(contract);
            return response;
        }
    }
}