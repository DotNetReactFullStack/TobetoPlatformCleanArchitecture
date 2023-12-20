using Application.Features.ExamQuestions.Constants;
using Application.Features.ExamQuestions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ExamQuestions.Constants.ExamQuestionsOperationClaims;

namespace Application.Features.ExamQuestions.Queries.GetById;

public class GetByIdExamQuestionQuery : IRequest<GetByIdExamQuestionResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdExamQuestionQueryHandler : IRequestHandler<GetByIdExamQuestionQuery, GetByIdExamQuestionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExamQuestionRepository _examQuestionRepository;
        private readonly ExamQuestionBusinessRules _examQuestionBusinessRules;

        public GetByIdExamQuestionQueryHandler(IMapper mapper, IExamQuestionRepository examQuestionRepository, ExamQuestionBusinessRules examQuestionBusinessRules)
        {
            _mapper = mapper;
            _examQuestionRepository = examQuestionRepository;
            _examQuestionBusinessRules = examQuestionBusinessRules;
        }

        public async Task<GetByIdExamQuestionResponse> Handle(GetByIdExamQuestionQuery request, CancellationToken cancellationToken)
        {
            ExamQuestion? examQuestion = await _examQuestionRepository.GetAsync(predicate: eq => eq.Id == request.Id, cancellationToken: cancellationToken);
            await _examQuestionBusinessRules.ExamQuestionShouldExistWhenSelected(examQuestion);

            GetByIdExamQuestionResponse response = _mapper.Map<GetByIdExamQuestionResponse>(examQuestion);
            return response;
        }
    }
}