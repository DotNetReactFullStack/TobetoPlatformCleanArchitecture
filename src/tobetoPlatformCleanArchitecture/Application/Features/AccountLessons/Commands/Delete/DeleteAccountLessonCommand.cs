using Application.Features.AccountLessons.Constants;
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

namespace Application.Features.AccountLessons.Commands.Delete;

public class DeleteAccountLessonCommand : IRequest<DeletedAccountLessonResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountLessonsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountLessons";

    public class DeleteAccountLessonCommandHandler : IRequestHandler<DeleteAccountLessonCommand, DeletedAccountLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountLessonRepository _accountLessonRepository;
        private readonly AccountLessonBusinessRules _accountLessonBusinessRules;

        public DeleteAccountLessonCommandHandler(IMapper mapper, IAccountLessonRepository accountLessonRepository,
                                         AccountLessonBusinessRules accountLessonBusinessRules)
        {
            _mapper = mapper;
            _accountLessonRepository = accountLessonRepository;
            _accountLessonBusinessRules = accountLessonBusinessRules;
        }

        public async Task<DeletedAccountLessonResponse> Handle(DeleteAccountLessonCommand request, CancellationToken cancellationToken)
        {
            AccountLesson? accountLesson = await _accountLessonRepository.GetAsync(predicate: al => al.Id == request.Id, cancellationToken: cancellationToken);
            await _accountLessonBusinessRules.AccountLessonShouldExistWhenSelected(accountLesson);

            await _accountLessonRepository.DeleteAsync(accountLesson!);

            DeletedAccountLessonResponse response = _mapper.Map<DeletedAccountLessonResponse>(accountLesson);
            return response;
        }
    }
}