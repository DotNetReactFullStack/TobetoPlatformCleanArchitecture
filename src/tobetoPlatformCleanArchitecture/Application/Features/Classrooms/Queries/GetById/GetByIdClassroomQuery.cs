using Application.Features.Classrooms.Constants;
using Application.Features.Classrooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Classrooms.Constants.ClassroomsOperationClaims;

namespace Application.Features.Classrooms.Queries.GetById;

public class GetByIdClassroomQuery : IRequest<GetByIdClassroomResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdClassroomQueryHandler : IRequestHandler<GetByIdClassroomQuery, GetByIdClassroomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassroomRepository _classroomRepository;
        private readonly ClassroomBusinessRules _classroomBusinessRules;

        public GetByIdClassroomQueryHandler(IMapper mapper, IClassroomRepository classroomRepository, ClassroomBusinessRules classroomBusinessRules)
        {
            _mapper = mapper;
            _classroomRepository = classroomRepository;
            _classroomBusinessRules = classroomBusinessRules;
        }

        public async Task<GetByIdClassroomResponse> Handle(GetByIdClassroomQuery request, CancellationToken cancellationToken)
        {
            Classroom? classroom = await _classroomRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _classroomBusinessRules.ClassroomShouldExistWhenSelected(classroom);

            GetByIdClassroomResponse response = _mapper.Map<GetByIdClassroomResponse>(classroom);
            return response;
        }
    }
}