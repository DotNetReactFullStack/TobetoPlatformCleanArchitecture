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
using Application.Features.OperationClaims.Constants;

namespace Application.Features.CourseCategories.Commands.Create;

public class CreateCourseCategoryCommand : IRequest<CreatedCourseCategoryResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, CourseCategoriesOperationClaims.Create, GeneralOperationClaims.Instructor };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCourseCategories";

    public class CreateCourseCategoryCommandHandler : IRequestHandler<CreateCourseCategoryCommand, CreatedCourseCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseCategoryRepository _courseCategoryRepository;
        private readonly CourseCategoryBusinessRules _courseCategoryBusinessRules;

        public CreateCourseCategoryCommandHandler(IMapper mapper, ICourseCategoryRepository courseCategoryRepository,
                                         CourseCategoryBusinessRules courseCategoryBusinessRules)
        {
            _mapper = mapper;
            _courseCategoryRepository = courseCategoryRepository;
            _courseCategoryBusinessRules = courseCategoryBusinessRules;
        }

        public async Task<CreatedCourseCategoryResponse> Handle(CreateCourseCategoryCommand request, CancellationToken cancellationToken)
        {
            CourseCategory courseCategory = _mapper.Map<CourseCategory>(request);

            await _courseCategoryRepository.AddAsync(courseCategory);

            CreatedCourseCategoryResponse response = _mapper.Map<CreatedCourseCategoryResponse>(courseCategory);
            return response;
        }
    }
}