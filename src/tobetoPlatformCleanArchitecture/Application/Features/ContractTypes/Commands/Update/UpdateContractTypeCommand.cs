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

namespace Application.Features.ContractTypes.Commands.Update;

public class UpdateContractTypeCommand : IRequest<UpdatedContractTypeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public string[] Roles => new[] { Admin, Write, ContractTypesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetContractTypes";

    public class UpdateContractTypeCommandHandler : IRequestHandler<UpdateContractTypeCommand, UpdatedContractTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IContractTypeRepository _contractTypeRepository;
        private readonly ContractTypeBusinessRules _contractTypeBusinessRules;

        public UpdateContractTypeCommandHandler(IMapper mapper, IContractTypeRepository contractTypeRepository,
                                         ContractTypeBusinessRules contractTypeBusinessRules)
        {
            _mapper = mapper;
            _contractTypeRepository = contractTypeRepository;
            _contractTypeBusinessRules = contractTypeBusinessRules;
        }

        public async Task<UpdatedContractTypeResponse> Handle(UpdateContractTypeCommand request, CancellationToken cancellationToken)
        {
            ContractType? contractType = await _contractTypeRepository.GetAsync(predicate: ct => ct.Id == request.Id, cancellationToken: cancellationToken);
            await _contractTypeBusinessRules.ContractTypeShouldExistWhenSelected(contractType);
            contractType = _mapper.Map(request, contractType);

            await _contractTypeRepository.UpdateAsync(contractType!);

            UpdatedContractTypeResponse response = _mapper.Map<UpdatedContractTypeResponse>(contractType);
            return response;
        }
    }
}