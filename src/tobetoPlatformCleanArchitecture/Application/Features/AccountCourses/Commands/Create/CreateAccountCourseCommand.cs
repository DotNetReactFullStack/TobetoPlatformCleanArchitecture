using Application.Features.AccountCourses.Constants;
using Application.Features.AccountCourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.AccountCourses.Constants.AccountCoursesOperationClaims;

namespace Application.Features.AccountCourses.Commands.Create;

public class CreateAccountCourseCommand : IRequest<CreatedAccountCourseResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int CourseId { get; set; }
    public int AccountId { get; set; }
    public bool IsActive { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountCoursesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountCourses";

    public class CreateAccountCourseCommandHandler : IRequestHandler<CreateAccountCourseCommand, CreatedAccountCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountCourseRepository _accountCourseRepository;
        private readonly AccountCourseBusinessRules _accountCourseBusinessRules;

        public CreateAccountCourseCommandHandler(IMapper mapper, IAccountCourseRepository accountCourseRepository,
                                         AccountCourseBusinessRules accountCourseBusinessRules)
        {
            _mapper = mapper;
            _accountCourseRepository = accountCourseRepository;
            _accountCourseBusinessRules = accountCourseBusinessRules;
        }

        public async Task<CreatedAccountCourseResponse> Handle(CreateAccountCourseCommand request, CancellationToken cancellationToken)
        {
            AccountCourse accountCourse = _mapper.Map<AccountCourse>(request);

            await _accountCourseRepository.AddAsync(accountCourse);

            CreatedAccountCourseResponse response = _mapper.Map<CreatedAccountCourseResponse>(accountCourse);
            return response;
        }
    }
}