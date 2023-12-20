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

namespace Application.Features.AccountLessons.Commands.Update;

public class UpdateAccountLessonCommand : IRequest<UpdatedAccountLessonResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int LessonId { get; set; }
    public int AccountId { get; set; }
    public int Points { get; set; }
    public bool IsComplete { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountLessonsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountLessons";

    public class UpdateAccountLessonCommandHandler : IRequestHandler<UpdateAccountLessonCommand, UpdatedAccountLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountLessonRepository _accountLessonRepository;
        private readonly AccountLessonBusinessRules _accountLessonBusinessRules;

        public UpdateAccountLessonCommandHandler(IMapper mapper, IAccountLessonRepository accountLessonRepository,
                                         AccountLessonBusinessRules accountLessonBusinessRules)
        {
            _mapper = mapper;
            _accountLessonRepository = accountLessonRepository;
            _accountLessonBusinessRules = accountLessonBusinessRules;
        }

        public async Task<UpdatedAccountLessonResponse> Handle(UpdateAccountLessonCommand request, CancellationToken cancellationToken)
        {
            AccountLesson? accountLesson = await _accountLessonRepository.GetAsync(predicate: al => al.Id == request.Id, cancellationToken: cancellationToken);
            await _accountLessonBusinessRules.AccountLessonShouldExistWhenSelected(accountLesson);
            accountLesson = _mapper.Map(request, accountLesson);

            await _accountLessonRepository.UpdateAsync(accountLesson!);

            UpdatedAccountLessonResponse response = _mapper.Map<UpdatedAccountLessonResponse>(accountLesson);
            return response;
        }
    }
}