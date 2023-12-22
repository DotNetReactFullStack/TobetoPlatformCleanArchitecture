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

namespace Application.Features.ClassroomExams.Commands.Update;

public class UpdateClassroomExamCommand : IRequest<UpdatedClassroomExamResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int ClassroomId { get; set; }
    public int ExamId { get; set; }
    public bool IsActive { get; set; }

    public string[] Roles => new[] { Admin, Write, ClassroomExamsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetClassroomExams";

    public class UpdateClassroomExamCommandHandler : IRequestHandler<UpdateClassroomExamCommand, UpdatedClassroomExamResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassroomExamRepository _classroomExamRepository;
        private readonly ClassroomExamBusinessRules _classroomExamBusinessRules;

        public UpdateClassroomExamCommandHandler(IMapper mapper, IClassroomExamRepository classroomExamRepository,
                                         ClassroomExamBusinessRules classroomExamBusinessRules)
        {
            _mapper = mapper;
            _classroomExamRepository = classroomExamRepository;
            _classroomExamBusinessRules = classroomExamBusinessRules;
        }

        public async Task<UpdatedClassroomExamResponse> Handle(UpdateClassroomExamCommand request, CancellationToken cancellationToken)
        {
            ClassroomExam? classroomExam = await _classroomExamRepository.GetAsync(predicate: ce => ce.Id == request.Id, cancellationToken: cancellationToken);
            await _classroomExamBusinessRules.ClassroomExamShouldExistWhenSelected(classroomExam);
            classroomExam = _mapper.Map(request, classroomExam);

            await _classroomExamRepository.UpdateAsync(classroomExam!);

            UpdatedClassroomExamResponse response = _mapper.Map<UpdatedClassroomExamResponse>(classroomExam);
            return response;
        }
    }
}