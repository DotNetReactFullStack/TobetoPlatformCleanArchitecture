using Application.Features.AccountExamResults.Constants;
using Application.Features.AccountExamResults.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.AccountExamResults.Constants.AccountExamResultsOperationClaims;

namespace Application.Features.AccountExamResults.Commands.Update;

public class UpdateAccountExamResultCommand : IRequest<UpdatedAccountExamResultResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int ExamId { get; set; }
    public bool Visibility { get; set; }
    public int NumberOfRightAnswers { get; set; }
    public int NumberOfWrongAnswers { get; set; }
    public int NumberOfNullAnswers { get; set; }
    public int Points { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountExamResultsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountExamResults";

    public class UpdateAccountExamResultCommandHandler : IRequestHandler<UpdateAccountExamResultCommand, UpdatedAccountExamResultResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountExamResultRepository _accountExamResultRepository;
        private readonly AccountExamResultBusinessRules _accountExamResultBusinessRules;

        public UpdateAccountExamResultCommandHandler(IMapper mapper, IAccountExamResultRepository accountExamResultRepository,
                                         AccountExamResultBusinessRules accountExamResultBusinessRules)
        {
            _mapper = mapper;
            _accountExamResultRepository = accountExamResultRepository;
            _accountExamResultBusinessRules = accountExamResultBusinessRules;
        }

        public async Task<UpdatedAccountExamResultResponse> Handle(UpdateAccountExamResultCommand request, CancellationToken cancellationToken)
        {
            AccountExamResult? accountExamResult = await _accountExamResultRepository.GetAsync(predicate: aer => aer.Id == request.Id, cancellationToken: cancellationToken);
            await _accountExamResultBusinessRules.AccountExamResultShouldExistWhenSelected(accountExamResult);
            accountExamResult = _mapper.Map(request, accountExamResult);

            await _accountExamResultRepository.UpdateAsync(accountExamResult!);

            UpdatedAccountExamResultResponse response = _mapper.Map<UpdatedAccountExamResultResponse>(accountExamResult);
            return response;
        }
    }
}