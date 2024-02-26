using Application.Features.AccountLearningPaths.Commands.Update.UpdateAccountLearningPathIsSaved;
using Application.Features.AccountLearningPaths.Constants;
using Application.Features.AccountLearningPaths.Rules;
using Application.Features.OperationClaims.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.AccountLearningPaths.Constants.AccountLearningPathsOperationClaims;


namespace Application.Features.AccountLearningPaths.Commands.Update.UpdateAccountLearningPathPercentComplete;
public class UpdateAccountLearningPathPercentCompleteCommand : IRequest<UpdatedAccountLearningPathResponse>//, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int AccountId { get; set; }
    public int LearningPathId { get; set; }
    public int TotalNumberOfPoints { get; set; }
    public byte PercentComplete { get; set; }
    public bool IsContinue { get; set; }
    public bool IsComplete { get; set; }


    public string[] Roles => new[] { Admin, Write, AccountLearningPathsOperationClaims.Update, GeneralOperationClaims.Instructor, GeneralOperationClaims.Student };
    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountLearningPaths";

    public class UpdateAccountLearningPathPercentCompleteCommandHandler : IRequestHandler<UpdateAccountLearningPathPercentCompleteCommand, UpdatedAccountLearningPathResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountLearningPathRepository _accountLearningPathRepository;
        private readonly AccountLearningPathBusinessRules _accountLearningPathBusinessRules;

        public UpdateAccountLearningPathPercentCompleteCommandHandler(IMapper mapper, IAccountLearningPathRepository accountLearningPathRepository,
                                         AccountLearningPathBusinessRules accountLearningPathBusinessRules)
        {
            _mapper = mapper;
            _accountLearningPathRepository = accountLearningPathRepository;
            _accountLearningPathBusinessRules = accountLearningPathBusinessRules;
        }

        public async Task<UpdatedAccountLearningPathResponse> Handle(UpdateAccountLearningPathPercentCompleteCommand request, CancellationToken cancellationToken)
        {
            AccountLearningPath? accountLearningPath = await _accountLearningPathRepository.GetAsync(predicate: alp => alp.AccountId == request.AccountId && alp.LearningPathId == request.LearningPathId, cancellationToken: cancellationToken);
            await _accountLearningPathBusinessRules.AccountLearningPathShouldExistWhenSelected(accountLearningPath);
            accountLearningPath = _mapper.Map(request, accountLearningPath);

            await _accountLearningPathRepository.UpdateAsync(accountLearningPath!);

            UpdatedAccountLearningPathResponse response = _mapper.Map<UpdatedAccountLearningPathResponse>(accountLearningPath);
            return response;
        }
    }
}
