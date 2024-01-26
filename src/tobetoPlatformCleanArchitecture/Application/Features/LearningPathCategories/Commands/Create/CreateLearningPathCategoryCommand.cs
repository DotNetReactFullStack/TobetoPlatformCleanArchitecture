using Application.Features.LearningPathCategories.Constants;
using Application.Features.LearningPathCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.LearningPathCategories.Constants.LearningPathCategoriesOperationClaims;

namespace Application.Features.LearningPathCategories.Commands.Create;

public class CreateLearningPathCategoryCommand : IRequest<CreatedLearningPathCategoryResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public string[] Roles => new[] { Admin, Write, LearningPathCategoriesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLearningPathCategories";

    public class CreateLearningPathCategoryCommandHandler : IRequestHandler<CreateLearningPathCategoryCommand, CreatedLearningPathCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILearningPathCategoryRepository _learningPathCategoryRepository;
        private readonly LearningPathCategoryBusinessRules _learningPathCategoryBusinessRules;

        public CreateLearningPathCategoryCommandHandler(IMapper mapper, ILearningPathCategoryRepository learningPathCategoryRepository,
                                         LearningPathCategoryBusinessRules learningPathCategoryBusinessRules)
        {
            _mapper = mapper;
            _learningPathCategoryRepository = learningPathCategoryRepository;
            _learningPathCategoryBusinessRules = learningPathCategoryBusinessRules;
        }

        public async Task<CreatedLearningPathCategoryResponse> Handle(CreateLearningPathCategoryCommand request, CancellationToken cancellationToken)
        {
            LearningPathCategory learningPathCategory = _mapper.Map<LearningPathCategory>(request);

            await _learningPathCategoryRepository.AddAsync(learningPathCategory);

            CreatedLearningPathCategoryResponse response = _mapper.Map<CreatedLearningPathCategoryResponse>(learningPathCategory);
            return response;
        }
    }
}