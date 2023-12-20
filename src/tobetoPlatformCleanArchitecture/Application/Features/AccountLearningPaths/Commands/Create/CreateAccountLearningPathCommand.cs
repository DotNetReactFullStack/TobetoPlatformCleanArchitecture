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

namespace Application.Features.AccountLearningPaths.Commands.Create;

public class CreateAccountLearningPathCommand : IRequest<CreatedAccountLearningPathResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int AccountId { get; set; }
    public int LearningPathId { get; set; }
    public int TotalNumberOfPoints { get; set; }
    public byte PercentComplete { get; set; }
    public bool IsContinue { get; set; }
    public bool IsComplete { get; set; }
    public bool IsLiked { get; set; }
    public bool IsSaved { get; set; }
    public bool IsActive { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountLearningPathsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountLearningPaths";

    public class CreateAccountLearningPathCommandHandler : IRequestHandler<CreateAccountLearningPathCommand, CreatedAccountLearningPathResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountLearningPathRepository _accountLearningPathRepository;
        private readonly AccountLearningPathBusinessRules _accountLearningPathBusinessRules;

        public CreateAccountLearningPathCommandHandler(IMapper mapper, IAccountLearningPathRepository accountLearningPathRepository,
                                         AccountLearningPathBusinessRules accountLearningPathBusinessRules)
        {
            _mapper = mapper;
            _accountLearningPathRepository = accountLearningPathRepository;
            _accountLearningPathBusinessRules = accountLearningPathBusinessRules;
        }

        public async Task<CreatedAccountLearningPathResponse> Handle(CreateAccountLearningPathCommand request, CancellationToken cancellationToken)
        {
            AccountLearningPath accountLearningPath = _mapper.Map<AccountLearningPath>(request);

            await _accountLearningPathRepository.AddAsync(accountLearningPath);

            CreatedAccountLearningPathResponse response = _mapper.Map<CreatedAccountLearningPathResponse>(accountLearningPath);
            return response;
        }
    }
}