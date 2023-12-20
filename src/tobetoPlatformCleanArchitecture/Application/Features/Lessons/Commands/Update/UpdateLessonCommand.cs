using Application.Features.Lessons.Constants;
using Application.Features.Lessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Lessons.Constants.LessonsOperationClaims;

namespace Application.Features.Lessons.Commands.Update;

public class UpdateLessonCommand : IRequest<UpdatedLessonResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public string Name { get; set; }
    public bool Visibility { get; set; }
    public string Language { get; set; }
    public string Content { get; set; }
    public int Duration { get; set; }
    public bool IsActive { get; set; }

    public string[] Roles => new[] { Admin, Write, LessonsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLessons";

    public class UpdateLessonCommandHandler : IRequestHandler<UpdateLessonCommand, UpdatedLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonRepository _lessonRepository;
        private readonly LessonBusinessRules _lessonBusinessRules;

        public UpdateLessonCommandHandler(IMapper mapper, ILessonRepository lessonRepository,
                                         LessonBusinessRules lessonBusinessRules)
        {
            _mapper = mapper;
            _lessonRepository = lessonRepository;
            _lessonBusinessRules = lessonBusinessRules;
        }

        public async Task<UpdatedLessonResponse> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
        {
            Lesson? lesson = await _lessonRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _lessonBusinessRules.LessonShouldExistWhenSelected(lesson);
            lesson = _mapper.Map(request, lesson);

            await _lessonRepository.UpdateAsync(lesson!);

            UpdatedLessonResponse response = _mapper.Map<UpdatedLessonResponse>(lesson);
            return response;
        }
    }
}