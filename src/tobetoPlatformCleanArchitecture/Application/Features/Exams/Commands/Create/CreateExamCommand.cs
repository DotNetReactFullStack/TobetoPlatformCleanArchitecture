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

namespace Application.Features.Exams.Commands.Create;

public class CreateExamCommand : IRequest<CreatedExamResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }
    public string Description { get; set; }
    public byte NumberOfQuestions { get; set; }
    public DateTime StartingTime { get; set; }
    public DateTime EndingTime { get; set; }
    public bool IsActive { get; set; }
    public short Duration { get; set; }

    public string[] Roles => new[] { Admin, Write, ExamsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetExams";

    public class CreateExamCommandHandler : IRequestHandler<CreateExamCommand, CreatedExamResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExamRepository _examRepository;
        private readonly ExamBusinessRules _examBusinessRules;

        public CreateExamCommandHandler(IMapper mapper, IExamRepository examRepository,
                                         ExamBusinessRules examBusinessRules)
        {
            _mapper = mapper;
            _examRepository = examRepository;
            _examBusinessRules = examBusinessRules;
        }

        public async Task<CreatedExamResponse> Handle(CreateExamCommand request, CancellationToken cancellationToken)
        {
            Exam exam = _mapper.Map<Exam>(request);

            await _examRepository.AddAsync(exam);

            CreatedExamResponse response = _mapper.Map<CreatedExamResponse>(exam);
            return response;
        }
    }
}