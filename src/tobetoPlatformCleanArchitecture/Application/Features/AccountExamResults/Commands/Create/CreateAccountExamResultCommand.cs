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

namespace Application.Features.AccountExamResults.Commands.Create;

public class CreateAccountExamResultCommand : IRequest<CreatedAccountExamResultResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int AccountId { get; set; }
    public int ExamId { get; set; }
    public bool Visibility { get; set; }
    public int NumberOfRightAnswers { get; set; }
    public int NumberOfWrongAnswers { get; set; }
    public int NumberOfNullAnswers { get; set; }
    public int Points { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountExamResultsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountExamResults";

    public class CreateAccountExamResultCommandHandler : IRequestHandler<CreateAccountExamResultCommand, CreatedAccountExamResultResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountExamResultRepository _accountExamResultRepository;
        private readonly AccountExamResultBusinessRules _accountExamResultBusinessRules;

        public CreateAccountExamResultCommandHandler(IMapper mapper, IAccountExamResultRepository accountExamResultRepository,
                                         AccountExamResultBusinessRules accountExamResultBusinessRules)
        {
            _mapper = mapper;
            _accountExamResultRepository = accountExamResultRepository;
            _accountExamResultBusinessRules = accountExamResultBusinessRules;
        }

        public async Task<CreatedAccountExamResultResponse> Handle(CreateAccountExamResultCommand request, CancellationToken cancellationToken)
        {
            AccountExamResult accountExamResult = _mapper.Map<AccountExamResult>(request);

            await _accountExamResultRepository.AddAsync(accountExamResult);

            CreatedAccountExamResultResponse response = _mapper.Map<CreatedAccountExamResultResponse>(accountExamResult);
            return response;
        }
    }
}