using Application.Features.ClassroomExams.Constants;
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

namespace Application.Features.ClassroomExams.Commands.Delete;

public class DeleteClassroomExamCommand : IRequest<DeletedClassroomExamResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ClassroomExamsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetClassroomExams";

    public class DeleteClassroomExamCommandHandler : IRequestHandler<DeleteClassroomExamCommand, DeletedClassroomExamResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassroomExamRepository _classroomExamRepository;
        private readonly ClassroomExamBusinessRules _classroomExamBusinessRules;

        public DeleteClassroomExamCommandHandler(IMapper mapper, IClassroomExamRepository classroomExamRepository,
                                         ClassroomExamBusinessRules classroomExamBusinessRules)
        {
            _mapper = mapper;
            _classroomExamRepository = classroomExamRepository;
            _classroomExamBusinessRules = classroomExamBusinessRules;
        }

        public async Task<DeletedClassroomExamResponse> Handle(DeleteClassroomExamCommand request, CancellationToken cancellationToken)
        {
            ClassroomExam? classroomExam = await _classroomExamRepository.GetAsync(predicate: ce => ce.Id == request.Id, cancellationToken: cancellationToken);
            await _classroomExamBusinessRules.ClassroomExamShouldExistWhenSelected(classroomExam);

            await _classroomExamRepository.DeleteAsync(classroomExam!);

            DeletedClassroomExamResponse response = _mapper.Map<DeletedClassroomExamResponse>(classroomExam);
            return response;
        }
    }
}