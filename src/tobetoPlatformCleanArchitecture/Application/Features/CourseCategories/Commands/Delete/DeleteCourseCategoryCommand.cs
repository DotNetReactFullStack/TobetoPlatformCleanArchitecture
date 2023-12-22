using Application.Features.CourseCategories.Constants;
using Application.Features.CourseCategories.Constants;
using Application.Features.CourseCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CourseCategories.Constants.CourseCategoriesOperationClaims;

namespace Application.Features.CourseCategories.Commands.Delete;

public class DeleteCourseCategoryCommand : IRequest<DeletedCourseCategoryResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CourseCategoriesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCourseCategories";

    public class DeleteCourseCategoryCommandHandler : IRequestHandler<DeleteCourseCategoryCommand, DeletedCourseCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseCategoryRepository _courseCategoryRepository;
        private readonly CourseCategoryBusinessRules _courseCategoryBusinessRules;

        public DeleteCourseCategoryCommandHandler(IMapper mapper, ICourseCategoryRepository courseCategoryRepository,
                                         CourseCategoryBusinessRules courseCategoryBusinessRules)
        {
            _mapper = mapper;
            _courseCategoryRepository = courseCategoryRepository;
            _courseCategoryBusinessRules = courseCategoryBusinessRules;
        }

        public async Task<DeletedCourseCategoryResponse> Handle(DeleteCourseCategoryCommand request, CancellationToken cancellationToken)
        {
            CourseCategory? courseCategory = await _courseCategoryRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _courseCategoryBusinessRules.CourseCategoryShouldExistWhenSelected(courseCategory);

            await _courseCategoryRepository.DeleteAsync(courseCategory!);

            DeletedCourseCategoryResponse response = _mapper.Map<DeletedCourseCategoryResponse>(courseCategory);
            return response;
        }
    }
}