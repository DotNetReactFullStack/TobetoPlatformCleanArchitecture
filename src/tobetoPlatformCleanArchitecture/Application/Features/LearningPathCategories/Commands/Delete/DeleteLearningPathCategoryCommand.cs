using Application.Features.LearningPathCategories.Constants;
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

namespace Application.Features.LearningPathCategories.Commands.Delete;

public class DeleteLearningPathCategoryCommand : IRequest<DeletedLearningPathCategoryResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, LearningPathCategoriesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetLearningPathCategories";

    public class DeleteLearningPathCategoryCommandHandler : IRequestHandler<DeleteLearningPathCategoryCommand, DeletedLearningPathCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILearningPathCategoryRepository _learningPathCategoryRepository;
        private readonly LearningPathCategoryBusinessRules _learningPathCategoryBusinessRules;

        public DeleteLearningPathCategoryCommandHandler(IMapper mapper, ILearningPathCategoryRepository learningPathCategoryRepository,
                                         LearningPathCategoryBusinessRules learningPathCategoryBusinessRules)
        {
            _mapper = mapper;
            _learningPathCategoryRepository = learningPathCategoryRepository;
            _learningPathCategoryBusinessRules = learningPathCategoryBusinessRules;
        }

        public async Task<DeletedLearningPathCategoryResponse> Handle(DeleteLearningPathCategoryCommand request, CancellationToken cancellationToken)
        {
            LearningPathCategory? learningPathCategory = await _learningPathCategoryRepository.GetAsync(predicate: lpc => lpc.Id == request.Id, cancellationToken: cancellationToken);
            await _learningPathCategoryBusinessRules.LearningPathCategoryShouldExistWhenSelected(learningPathCategory);

            await _learningPathCategoryRepository.DeleteAsync(learningPathCategory!);

            DeletedLearningPathCategoryResponse response = _mapper.Map<DeletedLearningPathCategoryResponse>(learningPathCategory);
            return response;
        }
    }
}