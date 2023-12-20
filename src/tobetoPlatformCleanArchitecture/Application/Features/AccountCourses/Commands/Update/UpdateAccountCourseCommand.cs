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

namespace Application.Features.AccountCourses.Commands.Update;

public class UpdateAccountCourseCommand : IRequest<UpdatedAccountCourseResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int AccountId { get; set; }
    public bool IsActive { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountCoursesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountCourses";

    public class UpdateAccountCourseCommandHandler : IRequestHandler<UpdateAccountCourseCommand, UpdatedAccountCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountCourseRepository _accountCourseRepository;
        private readonly AccountCourseBusinessRules _accountCourseBusinessRules;

        public UpdateAccountCourseCommandHandler(IMapper mapper, IAccountCourseRepository accountCourseRepository,
                                         AccountCourseBusinessRules accountCourseBusinessRules)
        {
            _mapper = mapper;
            _accountCourseRepository = accountCourseRepository;
            _accountCourseBusinessRules = accountCourseBusinessRules;
        }

        public async Task<UpdatedAccountCourseResponse> Handle(UpdateAccountCourseCommand request, CancellationToken cancellationToken)
        {
            AccountCourse? accountCourse = await _accountCourseRepository.GetAsync(predicate: ac => ac.Id == request.Id, cancellationToken: cancellationToken);
            await _accountCourseBusinessRules.AccountCourseShouldExistWhenSelected(accountCourse);
            accountCourse = _mapper.Map(request, accountCourse);

            await _accountCourseRepository.UpdateAsync(accountCourse!);

            UpdatedAccountCourseResponse response = _mapper.Map<UpdatedAccountCourseResponse>(accountCourse);
            return response;
        }
    }
}