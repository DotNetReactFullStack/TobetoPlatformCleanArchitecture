using Application.Features.ContractTypes.Constants;
using Application.Features.ContractTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ContractTypes.Constants.ContractTypesOperationClaims;

namespace Application.Features.ContractTypes.Commands.Create;

public class CreateContractTypeCommand : IRequest<CreatedContractTypeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public string[] Roles => new[] { Admin, Write, ContractTypesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetContractTypes";

    public class CreateContractTypeCommandHandler : IRequestHandler<CreateContractTypeCommand, CreatedContractTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IContractTypeRepository _contractTypeRepository;
        private readonly ContractTypeBusinessRules _contractTypeBusinessRules;

        public CreateContractTypeCommandHandler(IMapper mapper, IContractTypeRepository contractTypeRepository,
                                         ContractTypeBusinessRules contractTypeBusinessRules)
        {
            _mapper = mapper;
            _contractTypeRepository = contractTypeRepository;
            _contractTypeBusinessRules = contractTypeBusinessRules;
        }

        public async Task<CreatedContractTypeResponse> Handle(CreateContractTypeCommand request, CancellationToken cancellationToken)
        {
            ContractType contractType = _mapper.Map<ContractType>(request);

            await _contractTypeRepository.AddAsync(contractType);

            CreatedContractTypeResponse response = _mapper.Map<CreatedContractTypeResponse>(contractType);
            return response;
        }
    }
}