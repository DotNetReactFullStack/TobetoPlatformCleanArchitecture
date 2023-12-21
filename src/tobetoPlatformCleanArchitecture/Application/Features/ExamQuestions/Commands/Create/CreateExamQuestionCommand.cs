using Application.Features.ExamQuestions.Constants;
using Application.Features.ExamQuestions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ExamQuestions.Constants.ExamQuestionsOperationClaims;

namespace Application.Features.ExamQuestions.Commands.Create;

public class CreateExamQuestionCommand : IRequest<CreatedExamQuestionResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int ExamId { get; set; }
    public int QuestionId { get; set; }

    public string[] Roles => new[] { Admin, Write, ExamQuestionsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetExamQuestions";

    public class CreateExamQuestionCommandHandler : IRequestHandler<CreateExamQuestionCommand, CreatedExamQuestionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExamQuestionRepository _examQuestionRepository;
        private readonly ExamQuestionBusinessRules _examQuestionBusinessRules;

        public CreateExamQuestionCommandHandler(IMapper mapper, IExamQuestionRepository examQuestionRepository,
                                         ExamQuestionBusinessRules examQuestionBusinessRules)
        {
            _mapper = mapper;
            _examQuestionRepository = examQuestionRepository;
            _examQuestionBusinessRules = examQuestionBusinessRules;
        }

        public async Task<CreatedExamQuestionResponse> Handle(CreateExamQuestionCommand request, CancellationToken cancellationToken)
        {
            ExamQuestion examQuestion = _mapper.Map<ExamQuestion>(request);

            _examQuestionBusinessRules.ExamCanHasMaximumOneHundredQuestions(examQuestion);

            await _examQuestionRepository.AddAsync(examQuestion);

            CreatedExamQuestionResponse response = _mapper.Map<CreatedExamQuestionResponse>(examQuestion);
            return response;
        }
    }
}