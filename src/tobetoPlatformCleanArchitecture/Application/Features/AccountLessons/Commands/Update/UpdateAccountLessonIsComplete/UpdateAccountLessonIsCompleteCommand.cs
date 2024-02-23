using Application.Features.AccountLessons.Constants;
using Application.Features.AccountLessons.Rules;
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
using static Application.Features.AccountLessons.Constants.AccountLessonsOperationClaims;


namespace Application.Features.AccountLessons.Commands.Update.UpdateAccountLessonIsComplete;
public class UpdateAccountLessonIsCompleteCommand : IRequest<UpdatedAccountLessonResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int LessonId { get; set; }
    public int AccountId { get; set; }
    public int Points { get; set; }
    public bool IsComplete { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountLessonsOperationClaims.Update, GeneralOperationClaims.Instructor, GeneralOperationClaims.Student };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountLessons";

    public class UpdateAccountLessonIsCompleteCommandHandler : IRequestHandler<UpdateAccountLessonIsCompleteCommand, UpdatedAccountLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountLessonRepository _accountLessonRepository;
        private readonly AccountLessonBusinessRules _accountLessonBusinessRules;

        public UpdateAccountLessonIsCompleteCommandHandler(IMapper mapper, IAccountLessonRepository accountLessonRepository,
                                         AccountLessonBusinessRules accountLessonBusinessRules)
        {
            _mapper = mapper;
            _accountLessonRepository = accountLessonRepository;
            _accountLessonBusinessRules = accountLessonBusinessRules;
        }

        public async Task<UpdatedAccountLessonResponse> Handle(UpdateAccountLessonIsCompleteCommand request, CancellationToken cancellationToken)
        {
            AccountLesson? accountLesson = await _accountLessonRepository.GetAsync(predicate: al => al.AccountId == request.AccountId && al.LessonId == request.LessonId, cancellationToken: cancellationToken);
            await _accountLessonBusinessRules.AccountLessonShouldExistWhenSelected(accountLesson);
            accountLesson = _mapper.Map(request, accountLesson);

            await _accountLessonRepository.UpdateAsync(accountLesson!);

            UpdatedAccountLessonResponse response = _mapper.Map<UpdatedAccountLessonResponse>(accountLesson);
            return response;
        }
    }
}
