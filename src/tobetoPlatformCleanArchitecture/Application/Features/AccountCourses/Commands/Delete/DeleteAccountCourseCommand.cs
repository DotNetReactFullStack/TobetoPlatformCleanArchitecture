using Application.Features.AccountCourses.Constants;
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

namespace Application.Features.AccountCourses.Commands.Delete;

public class DeleteAccountCourseCommand : IRequest<DeletedAccountCourseResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountCoursesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountCourses";

    public class DeleteAccountCourseCommandHandler : IRequestHandler<DeleteAccountCourseCommand, DeletedAccountCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountCourseRepository _accountCourseRepository;
        private readonly AccountCourseBusinessRules _accountCourseBusinessRules;

        public DeleteAccountCourseCommandHandler(IMapper mapper, IAccountCourseRepository accountCourseRepository,
                                         AccountCourseBusinessRules accountCourseBusinessRules)
        {
            _mapper = mapper;
            _accountCourseRepository = accountCourseRepository;
            _accountCourseBusinessRules = accountCourseBusinessRules;
        }

        public async Task<DeletedAccountCourseResponse> Handle(DeleteAccountCourseCommand request, CancellationToken cancellationToken)
        {
            AccountCourse? accountCourse = await _accountCourseRepository.GetAsync(predicate: ac => ac.Id == request.Id, cancellationToken: cancellationToken);
            await _accountCourseBusinessRules.AccountCourseShouldExistWhenSelected(accountCourse);

            await _accountCourseRepository.DeleteAsync(accountCourse!);

            DeletedAccountCourseResponse response = _mapper.Map<DeletedAccountCourseResponse>(accountCourse);
            return response;
        }
    }
}