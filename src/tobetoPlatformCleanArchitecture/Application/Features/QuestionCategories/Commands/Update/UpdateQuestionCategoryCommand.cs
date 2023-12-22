using Application.Features.QuestionCategories.Constants;
using Application.Features.QuestionCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.QuestionCategories.Constants.QuestionCategoriesOperationClaims;

namespace Application.Features.QuestionCategories.Commands.Update;

public class UpdateQuestionCategoryCommand : IRequest<UpdatedQuestionCategoryResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }

    public string[] Roles => new[] { Admin, Write, QuestionCategoriesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetQuestionCategories";

    public class UpdateQuestionCategoryCommandHandler : IRequestHandler<UpdateQuestionCategoryCommand, UpdatedQuestionCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuestionCategoryRepository _questionCategoryRepository;
        private readonly QuestionCategoryBusinessRules _questionCategoryBusinessRules;

        public UpdateQuestionCategoryCommandHandler(IMapper mapper, IQuestionCategoryRepository questionCategoryRepository,
                                         QuestionCategoryBusinessRules questionCategoryBusinessRules)
        {
            _mapper = mapper;
            _questionCategoryRepository = questionCategoryRepository;
            _questionCategoryBusinessRules = questionCategoryBusinessRules;
        }

        public async Task<UpdatedQuestionCategoryResponse> Handle(UpdateQuestionCategoryCommand request, CancellationToken cancellationToken)
        {
            QuestionCategory? questionCategory = await _questionCategoryRepository.GetAsync(predicate: qc => qc.Id == request.Id, cancellationToken: cancellationToken);
            await _questionCategoryBusinessRules.QuestionCategoryShouldExistWhenSelected(questionCategory);
            questionCategory = _mapper.Map(request, questionCategory);

            await _questionCategoryRepository.UpdateAsync(questionCategory!);

            UpdatedQuestionCategoryResponse response = _mapper.Map<UpdatedQuestionCategoryResponse>(questionCategory);
            return response;
        }
    }
}