using Application.Features.Lessons.Constants;
using Application.Features.Lessons.Rules;
using Application.Features.OperationClaims.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;
using static Application.Features.Lessons.Constants.LessonsOperationClaims;


namespace Application.Features.Lessons.Commands.Update.UpdateLessonDuration;
public class UpdateLessonDurationCommand : IRequest<UpdatedLessonResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }   
    public int Duration { get; set; }

    public string[] Roles => new[] { Admin, Read, GeneralOperationClaims.Instructor, GeneralOperationClaims.Student };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLessons";

    public class UpdateLessonDurationCommandHandler : IRequestHandler<UpdateLessonDurationCommand, UpdatedLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonRepository _lessonRepository;
        private readonly LessonBusinessRules _lessonBusinessRules;

        public UpdateLessonDurationCommandHandler(IMapper mapper, ILessonRepository lessonRepository,
                                         LessonBusinessRules lessonBusinessRules)
        {
            _mapper = mapper;
            _lessonRepository = lessonRepository;
            _lessonBusinessRules = lessonBusinessRules;
        }

        public async Task<UpdatedLessonResponse> Handle(UpdateLessonDurationCommand request, CancellationToken cancellationToken)
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
