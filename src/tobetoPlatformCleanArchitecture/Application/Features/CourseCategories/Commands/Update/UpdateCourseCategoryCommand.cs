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

namespace Application.Features.CourseCategories.Commands.Update;

public class UpdateCourseCategoryCommand : IRequest<UpdatedCourseCategoryResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, CourseCategoriesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCourseCategories";

    public class UpdateCourseCategoryCommandHandler : IRequestHandler<UpdateCourseCategoryCommand, UpdatedCourseCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseCategoryRepository _courseCategoryRepository;
        private readonly CourseCategoryBusinessRules _courseCategoryBusinessRules;

        public UpdateCourseCategoryCommandHandler(IMapper mapper, ICourseCategoryRepository courseCategoryRepository,
                                         CourseCategoryBusinessRules courseCategoryBusinessRules)
        {
            _mapper = mapper;
            _courseCategoryRepository = courseCategoryRepository;
            _courseCategoryBusinessRules = courseCategoryBusinessRules;
        }

        public async Task<UpdatedCourseCategoryResponse> Handle(UpdateCourseCategoryCommand request, CancellationToken cancellationToken)
        {
            CourseCategory? courseCategory = await _courseCategoryRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _courseCategoryBusinessRules.CourseCategoryShouldExistWhenSelected(courseCategory);
            courseCategory = _mapper.Map(request, courseCategory);

            await _courseCategoryRepository.UpdateAsync(courseCategory!);

            UpdatedCourseCategoryResponse response = _mapper.Map<UpdatedCourseCategoryResponse>(courseCategory);
            return response;
        }
    }
}