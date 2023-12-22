using Application.Features.AccountLearningPaths.Constants;
using Application.Features.AccountLearningPaths.Constants;
using Application.Features.AccountLearningPaths.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.AccountLearningPaths.Constants.AccountLearningPathsOperationClaims;

namespace Application.Features.AccountLearningPaths.Commands.Delete;

public class DeleteAccountLearningPathCommand : IRequest<DeletedAccountLearningPathResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountLearningPathsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountLearningPaths";

    public class DeleteAccountLearningPathCommandHandler : IRequestHandler<DeleteAccountLearningPathCommand, DeletedAccountLearningPathResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountLearningPathRepository _accountLearningPathRepository;
        private readonly AccountLearningPathBusinessRules _accountLearningPathBusinessRules;

        public DeleteAccountLearningPathCommandHandler(IMapper mapper, IAccountLearningPathRepository accountLearningPathRepository,
                                         AccountLearningPathBusinessRules accountLearningPathBusinessRules)
        {
            _mapper = mapper;
            _accountLearningPathRepository = accountLearningPathRepository;
            _accountLearningPathBusinessRules = accountLearningPathBusinessRules;
        }

        public async Task<DeletedAccountLearningPathResponse> Handle(DeleteAccountLearningPathCommand request, CancellationToken cancellationToken)
        {
            AccountLearningPath? accountLearningPath = await _accountLearningPathRepository.GetAsync(predicate: alp => alp.Id == request.Id, cancellationToken: cancellationToken);
            await _accountLearningPathBusinessRules.AccountLearningPathShouldExistWhenSelected(accountLearningPath);

            await _accountLearningPathRepository.DeleteAsync(accountLearningPath!);

            DeletedAccountLearningPathResponse response = _mapper.Map<DeletedAccountLearningPathResponse>(accountLearningPath);
            return response;
        }
    }
}