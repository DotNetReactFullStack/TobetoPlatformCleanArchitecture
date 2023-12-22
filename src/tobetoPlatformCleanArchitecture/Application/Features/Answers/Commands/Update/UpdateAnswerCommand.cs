using Application.Features.Answers.Constants;
using Application.Features.Answers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Answers.Constants.AnswersOperationClaims;

namespace Application.Features.Answers.Commands.Update;

public class UpdateAnswerCommand : IRequest<UpdatedAnswerResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public string AnswerDetail { get; set; }
    public bool RightAnswerBool { get; set; }

    public string[] Roles => new[] { Admin, Write, AnswersOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAnswers";

    public class UpdateAnswerCommandHandler : IRequestHandler<UpdateAnswerCommand, UpdatedAnswerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAnswerRepository _answerRepository;
        private readonly AnswerBusinessRules _answerBusinessRules;

        public UpdateAnswerCommandHandler(IMapper mapper, IAnswerRepository answerRepository,
                                         AnswerBusinessRules answerBusinessRules)
        {
            _mapper = mapper;
            _answerRepository = answerRepository;
            _answerBusinessRules = answerBusinessRules;
        }

        public async Task<UpdatedAnswerResponse> Handle(UpdateAnswerCommand request, CancellationToken cancellationToken)
        {
            Answer? answer = await _answerRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _answerBusinessRules.AnswerShouldExistWhenSelected(answer);
            answer = _mapper.Map(request, answer);

            await _answerRepository.UpdateAsync(answer!);

            UpdatedAnswerResponse response = _mapper.Map<UpdatedAnswerResponse>(answer);
            return response;
        }
    }
}