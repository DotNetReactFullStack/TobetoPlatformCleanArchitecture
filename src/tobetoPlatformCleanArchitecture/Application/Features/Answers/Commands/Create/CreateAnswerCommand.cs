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

namespace Application.Features.Answers.Commands.Create;

public class CreateAnswerCommand : IRequest<CreatedAnswerResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int QuestionId { get; set; }
    public string AnswerDetail { get; set; }
    public bool RightAnswerBool { get; set; }

    public string[] Roles => new[] { Admin, Write, AnswersOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAnswers";

    public class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommand, CreatedAnswerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAnswerRepository _answerRepository;
        private readonly AnswerBusinessRules _answerBusinessRules;

        public CreateAnswerCommandHandler(IMapper mapper, IAnswerRepository answerRepository,
                                         AnswerBusinessRules answerBusinessRules)
        {
            _mapper = mapper;
            _answerRepository = answerRepository;
            _answerBusinessRules = answerBusinessRules;
        }

        public async Task<CreatedAnswerResponse> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
        {
            Answer answer = _mapper.Map<Answer>(request);

            await _answerRepository.AddAsync(answer);

            CreatedAnswerResponse response = _mapper.Map<CreatedAnswerResponse>(answer);
            return response;
        }
    }
}