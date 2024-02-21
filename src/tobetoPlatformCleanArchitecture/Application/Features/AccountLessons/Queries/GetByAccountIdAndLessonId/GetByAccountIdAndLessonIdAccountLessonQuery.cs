using Application.Features.AccountLessons.Queries.GetById;
using Application.Features.AccountLessons.Queries.GetList;
using Application.Features.AccountLessons.Rules;
using Application.Features.OperationClaims.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.AccountLessons.Constants.AccountLessonsOperationClaims;

namespace Application.Features.AccountLessons.Queries.GetListByAccountIdAndLessonId;
public class GetByAccountIdAndLessonIdAccountLessonQuery : IRequest<GetByAccountIdAndLessonIdAccountLessonResponse>, ISecuredRequest  
    
{
    public int AccountId { get; set; }
    public int LessonId { get; set; }

    public string[] Roles => new[] { Admin, Read, GeneralOperationClaims.Instructor, GeneralOperationClaims.Student };

    public class GetByAccountIdAndLessonIdAccountLessonQueryHandler : IRequestHandler<GetByAccountIdAndLessonIdAccountLessonQuery, GetByAccountIdAndLessonIdAccountLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountLessonRepository _accountLessonRepository;
        private readonly AccountLessonBusinessRules _accountLessonBusinessRules;

        public GetByAccountIdAndLessonIdAccountLessonQueryHandler(IMapper mapper, IAccountLessonRepository accountLessonRepository, AccountLessonBusinessRules accountLessonBusinessRules)
        {
            _mapper = mapper;
            _accountLessonRepository = accountLessonRepository;
            _accountLessonBusinessRules = accountLessonBusinessRules;
        }

        public async Task<GetByAccountIdAndLessonIdAccountLessonResponse> Handle(GetByAccountIdAndLessonIdAccountLessonQuery request, CancellationToken cancellationToken)
        {
            AccountLesson? accountLesson = await _accountLessonRepository.GetAsync(predicate: al => (al.AccountId == request.AccountId) && (al.LessonId == request.LessonId), cancellationToken: cancellationToken);
            await _accountLessonBusinessRules.AccountLessonShouldExistWhenSelected(accountLesson);

            GetByAccountIdAndLessonIdAccountLessonResponse response = _mapper.Map<GetByAccountIdAndLessonIdAccountLessonResponse>(accountLesson);
            return response;
        }
    }
}
