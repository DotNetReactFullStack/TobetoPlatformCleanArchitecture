using Application.Features.AccountLessons.Constants;
using Application.Features.AccountLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.AccountLessons.Constants.AccountLessonsOperationClaims;

namespace Application.Features.AccountLessons.Commands.Create;

public class CreateAccountLessonCommand : IRequest<CreatedAccountLessonResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int LessonId { get; set; }
    public int AccountId { get; set; }
    public int Points { get; set; }
    public bool IsComplete { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountLessonsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountLessons";

    public class CreateAccountLessonCommandHandler : IRequestHandler<CreateAccountLessonCommand, CreatedAccountLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountLessonRepository _accountLessonRepository;
        private readonly AccountLessonBusinessRules _accountLessonBusinessRules;

        public CreateAccountLessonCommandHandler(IMapper mapper, IAccountLessonRepository accountLessonRepository,
                                         AccountLessonBusinessRules accountLessonBusinessRules)
        {
            _mapper = mapper;
            _accountLessonRepository = accountLessonRepository;
            _accountLessonBusinessRules = accountLessonBusinessRules;
        }

        public async Task<CreatedAccountLessonResponse> Handle(CreateAccountLessonCommand request, CancellationToken cancellationToken)
        {
            AccountLesson accountLesson = _mapper.Map<AccountLesson>(request);

            await _accountLessonRepository.AddAsync(accountLesson);

            CreatedAccountLessonResponse response = _mapper.Map<CreatedAccountLessonResponse>(accountLesson);
            return response;
        }
    }
}