using Application.Features.AccountRecourses.Constants;
using Application.Features.AccountRecourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AccountRecourses.Constants.AccountRecoursesOperationClaims;

namespace Application.Features.AccountRecourses.Queries.GetById;

public class GetByIdAccountRecourseQuery : IRequest<GetByIdAccountRecourseResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdAccountRecourseQueryHandler : IRequestHandler<GetByIdAccountRecourseQuery, GetByIdAccountRecourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRecourseRepository _accountRecourseRepository;
        private readonly AccountRecourseBusinessRules _accountRecourseBusinessRules;

        public GetByIdAccountRecourseQueryHandler(IMapper mapper, IAccountRecourseRepository accountRecourseRepository, AccountRecourseBusinessRules accountRecourseBusinessRules)
        {
            _mapper = mapper;
            _accountRecourseRepository = accountRecourseRepository;
            _accountRecourseBusinessRules = accountRecourseBusinessRules;
        }

        public async Task<GetByIdAccountRecourseResponse> Handle(GetByIdAccountRecourseQuery request, CancellationToken cancellationToken)
        {
            AccountRecourse? accountRecourse = await _accountRecourseRepository.GetAsync(predicate: ar => ar.Id == request.Id, cancellationToken: cancellationToken);
            await _accountRecourseBusinessRules.AccountRecourseShouldExistWhenSelected(accountRecourse);

            GetByIdAccountRecourseResponse response = _mapper.Map<GetByIdAccountRecourseResponse>(accountRecourse);
            return response;
        }
    }
}