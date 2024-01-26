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

namespace Application.Features.Contracts.Commands.Update;

public class UpdateContractCommand : IRequest<UpdatedContractResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int ContractTypeId { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public bool IsActive { get; set; }

    public string[] Roles => new[] { Admin, Write, ContractsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetContracts";

    public class UpdateContractCommandHandler : IRequestHandler<UpdateContractCommand, UpdatedContractResponse>
    {
        private readonly IMapper _mapper;
        private readonly IContractRepository _contractRepository;
        private readonly ContractBusinessRules _contractBusinessRules;

        public UpdateContractCommandHandler(IMapper mapper, IContractRepository contractRepository,
                                         ContractBusinessRules contractBusinessRules)
        {
            _mapper = mapper;
            _contractRepository = contractRepository;
            _contractBusinessRules = contractBusinessRules;
        }

        public async Task<UpdatedContractResponse> Handle(UpdateContractCommand request, CancellationToken cancellationToken)
        {
            Contract? contract = await _contractRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _contractBusinessRules.ContractShouldExistWhenSelected(contract);
            contract = _mapper.Map(request, contract);

            await _contractRepository.UpdateAsync(contract!);

            UpdatedContractResponse response = _mapper.Map<UpdatedContractResponse>(contract);
            return response;
        }
    }
}