using Application.Features.ExamQuestions.Constants;
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

namespace Application.Features.ExamQuestions.Commands.Delete;

public class DeleteExamQuestionCommand : IRequest<DeletedExamQuestionResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ExamQuestionsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetExamQuestions";

    public class DeleteExamQuestionCommandHandler : IRequestHandler<DeleteExamQuestionCommand, DeletedExamQuestionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExamQuestionRepository _examQuestionRepository;
        private readonly ExamQuestionBusinessRules _examQuestionBusinessRules;

        public DeleteExamQuestionCommandHandler(IMapper mapper, IExamQuestionRepository examQuestionRepository,
                                         ExamQuestionBusinessRules examQuestionBusinessRules)
        {
            _mapper = mapper;
            _examQuestionRepository = examQuestionRepository;
            _examQuestionBusinessRules = examQuestionBusinessRules;
        }

        public async Task<DeletedExamQuestionResponse> Handle(DeleteExamQuestionCommand request, CancellationToken cancellationToken)
        {
            ExamQuestion? examQuestion = await _examQuestionRepository.GetAsync(predicate: eq => eq.Id == request.Id, cancellationToken: cancellationToken);
            await _examQuestionBusinessRules.ExamQuestionShouldExistWhenSelected(examQuestion);

            await _examQuestionRepository.DeleteAsync(examQuestion!);

            DeletedExamQuestionResponse response = _mapper.Map<DeletedExamQuestionResponse>(examQuestion);
            return response;
        }
    }
}