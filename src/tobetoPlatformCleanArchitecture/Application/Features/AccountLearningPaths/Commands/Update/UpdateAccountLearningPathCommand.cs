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

namespace Application.Features.AccountLearningPaths.Commands.Update;

public class UpdateAccountLearningPathCommand : IRequest<UpdatedAccountLearningPathResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int LearningPathId { get; set; }
    public int TotalNumberOfPoints { get; set; }
    public byte PercentComplete { get; set; }
    public bool IsContinue { get; set; }
    public bool IsComplete { get; set; }
    public bool IsLiked { get; set; }
    public bool IsSaved { get; set; }
    public bool IsActive { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountLearningPathsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountLearningPaths";

    public class UpdateAccountLearningPathCommandHandler : IRequestHandler<UpdateAccountLearningPathCommand, UpdatedAccountLearningPathResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountLearningPathRepository _accountLearningPathRepository;
        private readonly AccountLearningPathBusinessRules _accountLearningPathBusinessRules;

        public UpdateAccountLearningPathCommandHandler(IMapper mapper, IAccountLearningPathRepository accountLearningPathRepository,
                                         AccountLearningPathBusinessRules accountLearningPathBusinessRules)
        {
            _mapper = mapper;
            _accountLearningPathRepository = accountLearningPathRepository;
            _accountLearningPathBusinessRules = accountLearningPathBusinessRules;
        }

        public async Task<UpdatedAccountLearningPathResponse> Handle(UpdateAccountLearningPathCommand request, CancellationToken cancellationToken)
        {
            AccountLearningPath? accountLearningPath = await _accountLearningPathRepository.GetAsync(predicate: alp => alp.Id == request.Id, cancellationToken: cancellationToken);
            await _accountLearningPathBusinessRules.AccountLearningPathShouldExistWhenSelected(accountLearningPath);
            accountLearningPath = _mapper.Map(request, accountLearningPath);

            await _accountLearningPathRepository.UpdateAsync(accountLearningPath!);

            UpdatedAccountLearningPathResponse response = _mapper.Map<UpdatedAccountLearningPathResponse>(accountLearningPath);
            return response;
        }
    }
}