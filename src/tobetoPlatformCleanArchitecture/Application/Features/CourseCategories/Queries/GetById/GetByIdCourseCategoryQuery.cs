using Application.Features.CourseCategories.Constants;
using Application.Features.CourseCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CourseCategories.Constants.CourseCategoriesOperationClaims;

namespace Application.Features.CourseCategories.Queries.GetById;

public class GetByIdCourseCategoryQuery : IRequest<GetByIdCourseCategoryResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCourseCategoryQueryHandler : IRequestHandler<GetByIdCourseCategoryQuery, GetByIdCourseCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseCategoryRepository _courseCategoryRepository;
        private readonly CourseCategoryBusinessRules _courseCategoryBusinessRules;

        public GetByIdCourseCategoryQueryHandler(IMapper mapper, ICourseCategoryRepository courseCategoryRepository, CourseCategoryBusinessRules courseCategoryBusinessRules)
        {
            _mapper = mapper;
            _courseCategoryRepository = courseCategoryRepository;
            _courseCategoryBusinessRules = courseCategoryBusinessRules;
        }

        public async Task<GetByIdCourseCategoryResponse> Handle(GetByIdCourseCategoryQuery request, CancellationToken cancellationToken)
        {
            CourseCategory? courseCategory = await _courseCategoryRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _courseCategoryBusinessRules.CourseCategoryShouldExistWhenSelected(courseCategory);

            GetByIdCourseCategoryResponse response = _mapper.Map<GetByIdCourseCategoryResponse>(courseCategory);
            return response;
        }
    }
}