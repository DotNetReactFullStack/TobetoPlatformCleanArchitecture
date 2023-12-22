using Application.Features.QuestionCategories.Constants;
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

namespace Application.Features.QuestionCategories.Commands.Delete;

public class DeleteQuestionCategoryCommand : IRequest<DeletedQuestionCategoryResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, QuestionCategoriesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetQuestionCategories";

    public class DeleteQuestionCategoryCommandHandler : IRequestHandler<DeleteQuestionCategoryCommand, DeletedQuestionCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuestionCategoryRepository _questionCategoryRepository;
        private readonly QuestionCategoryBusinessRules _questionCategoryBusinessRules;

        public DeleteQuestionCategoryCommandHandler(IMapper mapper, IQuestionCategoryRepository questionCategoryRepository,
                                         QuestionCategoryBusinessRules questionCategoryBusinessRules)
        {
            _mapper = mapper;
            _questionCategoryRepository = questionCategoryRepository;
            _questionCategoryBusinessRules = questionCategoryBusinessRules;
        }

        public async Task<DeletedQuestionCategoryResponse> Handle(DeleteQuestionCategoryCommand request, CancellationToken cancellationToken)
        {
            QuestionCategory? questionCategory = await _questionCategoryRepository.GetAsync(predicate: qc => qc.Id == request.Id, cancellationToken: cancellationToken);
            await _questionCategoryBusinessRules.QuestionCategoryShouldExistWhenSelected(questionCategory);

            await _questionCategoryRepository.DeleteAsync(questionCategory!);

            DeletedQuestionCategoryResponse response = _mapper.Map<DeletedQuestionCategoryResponse>(questionCategory);
            return response;
        }
    }
}