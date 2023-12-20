using Application.Features.AccountCourses.Constants;
using Application.Features.AccountCourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AccountCourses.Constants.AccountCoursesOperationClaims;

namespace Application.Features.AccountCourses.Queries.GetById;

public class GetByIdAccountCourseQuery : IRequest<GetByIdAccountCourseResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdAccountCourseQueryHandler : IRequestHandler<GetByIdAccountCourseQuery, GetByIdAccountCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountCourseRepository _accountCourseRepository;
        private readonly AccountCourseBusinessRules _accountCourseBusinessRules;

        public GetByIdAccountCourseQueryHandler(IMapper mapper, IAccountCourseRepository accountCourseRepository, AccountCourseBusinessRules accountCourseBusinessRules)
        {
            _mapper = mapper;
            _accountCourseRepository = accountCourseRepository;
            _accountCourseBusinessRules = accountCourseBusinessRules;
        }

        public async Task<GetByIdAccountCourseResponse> Handle(GetByIdAccountCourseQuery request, CancellationToken cancellationToken)
        {
            AccountCourse? accountCourse = await _accountCourseRepository.GetAsync(predicate: ac => ac.Id == request.Id, cancellationToken: cancellationToken);
            await _accountCourseBusinessRules.AccountCourseShouldExistWhenSelected(accountCourse);

            GetByIdAccountCourseResponse response = _mapper.Map<GetByIdAccountCourseResponse>(accountCourse);
            return response;
        }
    }
}