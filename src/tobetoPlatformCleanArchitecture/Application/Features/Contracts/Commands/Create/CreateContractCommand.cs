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

namespace Application.Features.Contracts.Commands.Create;

public class CreateContractCommand : IRequest<CreatedContractResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int ContractTypeId { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public bool IsActive { get; set; }

    public string[] Roles => new[] { Admin, Write, ContractsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetContracts";

    public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand, CreatedContractResponse>
    {
        private readonly IMapper _mapper;
        private readonly IContractRepository _contractRepository;
        private readonly ContractBusinessRules _contractBusinessRules;

        public CreateContractCommandHandler(IMapper mapper, IContractRepository contractRepository,
                                         ContractBusinessRules contractBusinessRules)
        {
            _mapper = mapper;
            _contractRepository = contractRepository;
            _contractBusinessRules = contractBusinessRules;
        }

        public async Task<CreatedContractResponse> Handle(CreateContractCommand request, CancellationToken cancellationToken)
        {
            Contract contract = _mapper.Map<Contract>(request);

            await _contractRepository.AddAsync(contract);

            CreatedContractResponse response = _mapper.Map<CreatedContractResponse>(contract);
            return response;
        }
    }
}