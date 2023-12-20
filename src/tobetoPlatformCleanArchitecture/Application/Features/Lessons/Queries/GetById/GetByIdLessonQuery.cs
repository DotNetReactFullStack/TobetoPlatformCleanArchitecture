using Application.Features.Lessons.Constants;
using Application.Features.Lessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Lessons.Constants.LessonsOperationClaims;

namespace Application.Features.Lessons.Queries.GetById;

public class GetByIdLessonQuery : IRequest<GetByIdLessonResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdLessonQueryHandler : IRequestHandler<GetByIdLessonQuery, GetByIdLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonRepository _lessonRepository;
        private readonly LessonBusinessRules _lessonBusinessRules;

        public GetByIdLessonQueryHandler(IMapper mapper, ILessonRepository lessonRepository, LessonBusinessRules lessonBusinessRules)
        {
            _mapper = mapper;
            _lessonRepository = lessonRepository;
            _lessonBusinessRules = lessonBusinessRules;
        }

        public async Task<GetByIdLessonResponse> Handle(GetByIdLessonQuery request, CancellationToken cancellationToken)
        {
            Lesson? lesson = await _lessonRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _lessonBusinessRules.LessonShouldExistWhenSelected(lesson);

            GetByIdLessonResponse response = _mapper.Map<GetByIdLessonResponse>(lesson);
            return response;
        }
    }
}