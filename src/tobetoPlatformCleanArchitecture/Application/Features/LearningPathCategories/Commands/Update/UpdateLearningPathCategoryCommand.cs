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

namespace Application.Features.LearningPathCategories.Commands.Update;

public class UpdateLearningPathCategoryCommand : IRequest<UpdatedLearningPathCategoryResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public string[] Roles => new[] { Admin, Write, LearningPathCategoriesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLearningPathCategories";

    public class UpdateLearningPathCategoryCommandHandler : IRequestHandler<UpdateLearningPathCategoryCommand, UpdatedLearningPathCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILearningPathCategoryRepository _learningPathCategoryRepository;
        private readonly LearningPathCategoryBusinessRules _learningPathCategoryBusinessRules;

        public UpdateLearningPathCategoryCommandHandler(IMapper mapper, ILearningPathCategoryRepository learningPathCategoryRepository,
                                         LearningPathCategoryBusinessRules learningPathCategoryBusinessRules)
        {
            _mapper = mapper;
            _learningPathCategoryRepository = learningPathCategoryRepository;
            _learningPathCategoryBusinessRules = learningPathCategoryBusinessRules;
        }

        public async Task<UpdatedLearningPathCategoryResponse> Handle(UpdateLearningPathCategoryCommand request, CancellationToken cancellationToken)
        {
            LearningPathCategory? learningPathCategory = await _learningPathCategoryRepository.GetAsync(predicate: lpc => lpc.Id == request.Id, cancellationToken: cancellationToken);
            await _learningPathCategoryBusinessRules.LearningPathCategoryShouldExistWhenSelected(learningPathCategory);
            learningPathCategory = _mapper.Map(request, learningPathCategory);

            await _learningPathCategoryRepository.UpdateAsync(learningPathCategory!);

            UpdatedLearningPathCategoryResponse response = _mapper.Map<UpdatedLearningPathCategoryResponse>(learningPathCategory);
            return response;
        }
    }
}