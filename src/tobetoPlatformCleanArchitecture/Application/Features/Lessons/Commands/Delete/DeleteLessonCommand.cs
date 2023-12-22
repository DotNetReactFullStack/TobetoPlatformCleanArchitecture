using Application.Features.Lessons.Constants;
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

namespace Application.Features.Lessons.Commands.Delete;

public class DeleteLessonCommand : IRequest<DeletedLessonResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, LessonsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLessons";

    public class DeleteLessonCommandHandler : IRequestHandler<DeleteLessonCommand, DeletedLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonRepository _lessonRepository;
        private readonly LessonBusinessRules _lessonBusinessRules;

        public DeleteLessonCommandHandler(IMapper mapper, ILessonRepository lessonRepository,
                                         LessonBusinessRules lessonBusinessRules)
        {
            _mapper = mapper;
            _lessonRepository = lessonRepository;
            _lessonBusinessRules = lessonBusinessRules;
        }

        public async Task<DeletedLessonResponse> Handle(DeleteLessonCommand request, CancellationToken cancellationToken)
        {
            Lesson? lesson = await _lessonRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _lessonBusinessRules.LessonShouldExistWhenSelected(lesson);

            await _lessonRepository.DeleteAsync(lesson!);

            DeletedLessonResponse response = _mapper.Map<DeletedLessonResponse>(lesson);
            return response;
        }
    }
}