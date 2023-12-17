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

namespace Application.Features.QuestionCategories.Commands.Create;

public class CreateQuestionCategoryCommand : IRequest<CreatedQuestionCategoryResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public int Priority { get; set; }

    public string[] Roles => new[] { Admin, Write, QuestionCategoriesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetQuestionCategories";

    public class CreateQuestionCategoryCommandHandler : IRequestHandler<CreateQuestionCategoryCommand, CreatedQuestionCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuestionCategoryRepository _questionCategoryRepository;
        private readonly QuestionCategoryBusinessRules _questionCategoryBusinessRules;

        public CreateQuestionCategoryCommandHandler(IMapper mapper, IQuestionCategoryRepository questionCategoryRepository,
                                         QuestionCategoryBusinessRules questionCategoryBusinessRules)
        {
            _mapper = mapper;
            _questionCategoryRepository = questionCategoryRepository;
            _questionCategoryBusinessRules = questionCategoryBusinessRules;
        }

        public async Task<CreatedQuestionCategoryResponse> Handle(CreateQuestionCategoryCommand request, CancellationToken cancellationToken)
        {
            QuestionCategory questionCategory = _mapper.Map<QuestionCategory>(request);

            await _questionCategoryRepository.AddAsync(questionCategory);

            CreatedQuestionCategoryResponse response = _mapper.Map<CreatedQuestionCategoryResponse>(questionCategory);
            return response;
        }
    }
}