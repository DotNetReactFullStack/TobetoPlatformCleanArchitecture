using Application.Features.LearningPathCategories.Constants;
using Application.Features.LearningPathCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.LearningPathCategories.Constants.LearningPathCategoriesOperationClaims;

namespace Application.Features.LearningPathCategories.Queries.GetById;

public class GetByIdLearningPathCategoryQuery : IRequest<GetByIdLearningPathCategoryResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdLearningPathCategoryQueryHandler : IRequestHandler<GetByIdLearningPathCategoryQuery, GetByIdLearningPathCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILearningPathCategoryRepository _learningPathCategoryRepository;
        private readonly LearningPathCategoryBusinessRules _learningPathCategoryBusinessRules;

        public GetByIdLearningPathCategoryQueryHandler(IMapper mapper, ILearningPathCategoryRepository learningPathCategoryRepository, LearningPathCategoryBusinessRules learningPathCategoryBusinessRules)
        {
            _mapper = mapper;
            _learningPathCategoryRepository = learningPathCategoryRepository;
            _learningPathCategoryBusinessRules = learningPathCategoryBusinessRules;
        }

        public async Task<GetByIdLearningPathCategoryResponse> Handle(GetByIdLearningPathCategoryQuery request, CancellationToken cancellationToken)
        {
            LearningPathCategory? learningPathCategory = await _learningPathCategoryRepository.GetAsync(predicate: lpc => lpc.Id == request.Id, cancellationToken: cancellationToken);
            await _learningPathCategoryBusinessRules.LearningPathCategoryShouldExistWhenSelected(learningPathCategory);

            GetByIdLearningPathCategoryResponse response = _mapper.Map<GetByIdLearningPathCategoryResponse>(learningPathCategory);
            return response;
        }
    }
}