using Application.Features.Answers.Constants;
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

namespace Application.Features.Answers.Commands.Delete;

public class DeleteAnswerCommand : IRequest<DeletedAnswerResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, AnswersOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAnswers";

    public class DeleteAnswerCommandHandler : IRequestHandler<DeleteAnswerCommand, DeletedAnswerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAnswerRepository _answerRepository;
        private readonly AnswerBusinessRules _answerBusinessRules;

        public DeleteAnswerCommandHandler(IMapper mapper, IAnswerRepository answerRepository,
                                         AnswerBusinessRules answerBusinessRules)
        {
            _mapper = mapper;
            _answerRepository = answerRepository;
            _answerBusinessRules = answerBusinessRules;
        }

        public async Task<DeletedAnswerResponse> Handle(DeleteAnswerCommand request, CancellationToken cancellationToken)
        {
            Answer? answer = await _answerRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _answerBusinessRules.AnswerShouldExistWhenSelected(answer);

            await _answerRepository.DeleteAsync(answer!);

            DeletedAnswerResponse response = _mapper.Map<DeletedAnswerResponse>(answer);
            return response;
        }
    }
}