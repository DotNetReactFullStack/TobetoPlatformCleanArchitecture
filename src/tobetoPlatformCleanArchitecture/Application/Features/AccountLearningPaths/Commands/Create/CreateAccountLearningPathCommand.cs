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
using Application.Services.CourseLearningPaths;
using Application.Services.AccountCourses;

namespace Application.Features.AccountLearningPaths.Commands.Create;

public class CreateAccountLearningPathCommand : IRequest<CreatedAccountLearningPathResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
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

        private readonly ICourseLearningPathsService _courseLearningPathsService;
        private readonly IAccountCoursesService _accountCoursesService;

        public CreateAccountLearningPathCommandHandler(IMapper mapper, IAccountLearningPathRepository accountLearningPathRepository,
                                         AccountLearningPathBusinessRules accountLearningPathBusinessRules, ICourseLearningPathsService courseLearningPathsService, IAccountCoursesService accountCoursesService)
        {
            _mapper = mapper;
            _accountLearningPathRepository = accountLearningPathRepository;
            _accountLearningPathBusinessRules = accountLearningPathBusinessRules;

            _courseLearningPathsService = courseLearningPathsService;
            _accountCoursesService = accountCoursesService;
        }

        public async Task<CreatedAccountLearningPathResponse> Handle(CreateAccountLearningPathCommand request, CancellationToken cancellationToken)
        {
            AccountLearningPath accountLearningPath = _mapper.Map<AccountLearningPath>(request);

            AccountLearningPath createdAccountLearningPath = await _accountLearningPathRepository.AddAsync(accountLearningPath);

            List<int> courseIds = await _courseLearningPathsService.GetListByLearningPathIdCourseIds(createdAccountLearningPath.LearningPathId);

            foreach (var courseId in courseIds)
            {
                using (AccountCourse accountCourse = new AccountCourse(courseId: courseId, accountId: request.AccountId, isActive: true))
                {
                    await _accountCoursesService.AddAsync(accountCourse);
                }
            }

            CreatedAccountLearningPathResponse response = _mapper.Map<CreatedAccountLearningPathResponse>(accountLearningPath);
            return response;
        }
    }
}