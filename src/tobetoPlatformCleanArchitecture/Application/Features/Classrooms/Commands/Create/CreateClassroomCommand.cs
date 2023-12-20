using Application.Features.Classrooms.Constants;
using Application.Features.Classrooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Classrooms.Constants.ClassroomsOperationClaims;

namespace Application.Features.Classrooms.Commands.Create;

public class CreateClassroomCommand : IRequest<CreatedClassroomResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public byte MaximumCapacity { get; set; }
    public bool IsActive { get; set; }

    public string[] Roles => new[] { Admin, Write, ClassroomsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetClassrooms";

    public class CreateClassroomCommandHandler : IRequestHandler<CreateClassroomCommand, CreatedClassroomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassroomRepository _classroomRepository;
        private readonly ClassroomBusinessRules _classroomBusinessRules;

        public CreateClassroomCommandHandler(IMapper mapper, IClassroomRepository classroomRepository,
                                         ClassroomBusinessRules classroomBusinessRules)
        {
            _mapper = mapper;
            _classroomRepository = classroomRepository;
            _classroomBusinessRules = classroomBusinessRules;
        }

        public async Task<CreatedClassroomResponse> Handle(CreateClassroomCommand request, CancellationToken cancellationToken)
        {
            Classroom classroom = _mapper.Map<Classroom>(request);

            await _classroomRepository.AddAsync(classroom);

            CreatedClassroomResponse response = _mapper.Map<CreatedClassroomResponse>(classroom);
            return response;
        }
    }
}