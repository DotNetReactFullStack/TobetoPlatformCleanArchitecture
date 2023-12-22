using Application.Features.Questions.Constants;
using Application.Features.Questions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Questions.Constants.QuestionsOperationClaims;

namespace Application.Features.Questions.Commands.Update;

public class UpdateQuestionCommand : IRequest<UpdatedQuestionResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int QuestionCategoryId { get; set; }
    public string QuestionDetail { get; set; }
    public bool IsActive { get; set; }

    public string[] Roles => new[] { Admin, Write, QuestionsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetQuestions";

    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, UpdatedQuestionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;
        private readonly QuestionBusinessRules _questionBusinessRules;

        public UpdateQuestionCommandHandler(IMapper mapper, IQuestionRepository questionRepository,
                                         QuestionBusinessRules questionBusinessRules)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
            _questionBusinessRules = questionBusinessRules;
        }

        public async Task<UpdatedQuestionResponse> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            Question? question = await _questionRepository.GetAsync(predicate: q => q.Id == request.Id, cancellationToken: cancellationToken);
            await _questionBusinessRules.QuestionShouldExistWhenSelected(question);
            question = _mapper.Map(request, question);

            await _questionRepository.UpdateAsync(question!);

            UpdatedQuestionResponse response = _mapper.Map<UpdatedQuestionResponse>(question);
            return response;
        }
    }
}