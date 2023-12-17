using Application.Features.ClassroomExams.Constants;
using Application.Features.ClassroomExams.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ClassroomExams.Constants.ClassroomExamsOperationClaims;

namespace Application.Features.ClassroomExams.Commands.Create;

public class CreateClassroomExamCommand : IRequest<CreatedClassroomExamResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int ClassroomId { get; set; }
    public int ExamId { get; set; }
    public bool IsActive { get; set; }

    public string[] Roles => new[] { Admin, Write, ClassroomExamsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetClassroomExams";

    public class CreateClassroomExamCommandHandler : IRequestHandler<CreateClassroomExamCommand, CreatedClassroomExamResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassroomExamRepository _classroomExamRepository;
        private readonly ClassroomExamBusinessRules _classroomExamBusinessRules;

        public CreateClassroomExamCommandHandler(IMapper mapper, IClassroomExamRepository classroomExamRepository,
                                         ClassroomExamBusinessRules classroomExamBusinessRules)
        {
            _mapper = mapper;
            _classroomExamRepository = classroomExamRepository;
            _classroomExamBusinessRules = classroomExamBusinessRules;
        }

        public async Task<CreatedClassroomExamResponse> Handle(CreateClassroomExamCommand request, CancellationToken cancellationToken)
        {
            ClassroomExam classroomExam = _mapper.Map<ClassroomExam>(request);

            await _classroomExamRepository.AddAsync(classroomExam);

            CreatedClassroomExamResponse response = _mapper.Map<CreatedClassroomExamResponse>(classroomExam);
            return response;
        }
    }
}