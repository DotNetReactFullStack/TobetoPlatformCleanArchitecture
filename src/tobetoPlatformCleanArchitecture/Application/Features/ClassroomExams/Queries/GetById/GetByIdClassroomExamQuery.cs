using Application.Features.ClassroomExams.Constants;
using Application.Features.ClassroomExams.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ClassroomExams.Constants.ClassroomExamsOperationClaims;

namespace Application.Features.ClassroomExams.Queries.GetById;

public class GetByIdClassroomExamQuery : IRequest<GetByIdClassroomExamResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdClassroomExamQueryHandler : IRequestHandler<GetByIdClassroomExamQuery, GetByIdClassroomExamResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassroomExamRepository _classroomExamRepository;
        private readonly ClassroomExamBusinessRules _classroomExamBusinessRules;

        public GetByIdClassroomExamQueryHandler(IMapper mapper, IClassroomExamRepository classroomExamRepository, ClassroomExamBusinessRules classroomExamBusinessRules)
        {
            _mapper = mapper;
            _classroomExamRepository = classroomExamRepository;
            _classroomExamBusinessRules = classroomExamBusinessRules;
        }

        public async Task<GetByIdClassroomExamResponse> Handle(GetByIdClassroomExamQuery request, CancellationToken cancellationToken)
        {
            ClassroomExam? classroomExam = await _classroomExamRepository.GetAsync(predicate: ce => ce.Id == request.Id, cancellationToken: cancellationToken);
            await _classroomExamBusinessRules.ClassroomExamShouldExistWhenSelected(classroomExam);

            GetByIdClassroomExamResponse response = _mapper.Map<GetByIdClassroomExamResponse>(classroomExam);
            return response;
        }
    }
}