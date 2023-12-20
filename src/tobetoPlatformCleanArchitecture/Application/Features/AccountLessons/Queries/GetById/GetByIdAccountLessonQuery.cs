using Application.Features.AccountLessons.Constants;
using Application.Features.AccountLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AccountLessons.Constants.AccountLessonsOperationClaims;

namespace Application.Features.AccountLessons.Queries.GetById;

public class GetByIdAccountLessonQuery : IRequest<GetByIdAccountLessonResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdAccountLessonQueryHandler : IRequestHandler<GetByIdAccountLessonQuery, GetByIdAccountLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountLessonRepository _accountLessonRepository;
        private readonly AccountLessonBusinessRules _accountLessonBusinessRules;

        public GetByIdAccountLessonQueryHandler(IMapper mapper, IAccountLessonRepository accountLessonRepository, AccountLessonBusinessRules accountLessonBusinessRules)
        {
            _mapper = mapper;
            _accountLessonRepository = accountLessonRepository;
            _accountLessonBusinessRules = accountLessonBusinessRules;
        }

        public async Task<GetByIdAccountLessonResponse> Handle(GetByIdAccountLessonQuery request, CancellationToken cancellationToken)
        {
            AccountLesson? accountLesson = await _accountLessonRepository.GetAsync(predicate: al => al.Id == request.Id, cancellationToken: cancellationToken);
            await _accountLessonBusinessRules.AccountLessonShouldExistWhenSelected(accountLesson);

            GetByIdAccountLessonResponse response = _mapper.Map<GetByIdAccountLessonResponse>(accountLesson);
            return response;
        }
    }
}