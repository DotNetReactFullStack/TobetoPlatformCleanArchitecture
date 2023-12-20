using Application.Features.Exams.Constants;
using Application.Features.Exams.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Exams.Constants.ExamsOperationClaims;

namespace Application.Features.Exams.Commands.Update;

public class UpdateExamCommand : IRequest<UpdatedExamResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
    public string Description { get; set; }
    public byte NumberOfQuestions { get; set; }
    public DateTime StartingTime { get; set; }
    public DateTime EndingTime { get; set; }
    public bool IsActive { get; set; }
    public short Duration { get; set; }

    public string[] Roles => new[] { Admin, Write, ExamsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetExams";

    public class UpdateExamCommandHandler : IRequestHandler<UpdateExamCommand, UpdatedExamResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExamRepository _examRepository;
        private readonly ExamBusinessRules _examBusinessRules;

        public UpdateExamCommandHandler(IMapper mapper, IExamRepository examRepository,
                                         ExamBusinessRules examBusinessRules)
        {
            _mapper = mapper;
            _examRepository = examRepository;
            _examBusinessRules = examBusinessRules;
        }

        public async Task<UpdatedExamResponse> Handle(UpdateExamCommand request, CancellationToken cancellationToken)
        {
            Exam? exam = await _examRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _examBusinessRules.ExamShouldExistWhenSelected(exam);
            exam = _mapper.Map(request, exam);

            await _examRepository.UpdateAsync(exam!);

            UpdatedExamResponse response = _mapper.Map<UpdatedExamResponse>(exam);
            return response;
        }
    }
}