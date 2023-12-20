using Application.Features.QuestionCategories.Constants;
using Application.Features.QuestionCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.QuestionCategories.Constants.QuestionCategoriesOperationClaims;

namespace Application.Features.QuestionCategories.Queries.GetById;

public class GetByIdQuestionCategoryQuery : IRequest<GetByIdQuestionCategoryResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdQuestionCategoryQueryHandler : IRequestHandler<GetByIdQuestionCategoryQuery, GetByIdQuestionCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuestionCategoryRepository _questionCategoryRepository;
        private readonly QuestionCategoryBusinessRules _questionCategoryBusinessRules;

        public GetByIdQuestionCategoryQueryHandler(IMapper mapper, IQuestionCategoryRepository questionCategoryRepository, QuestionCategoryBusinessRules questionCategoryBusinessRules)
        {
            _mapper = mapper;
            _questionCategoryRepository = questionCategoryRepository;
            _questionCategoryBusinessRules = questionCategoryBusinessRules;
        }

        public async Task<GetByIdQuestionCategoryResponse> Handle(GetByIdQuestionCategoryQuery request, CancellationToken cancellationToken)
        {
            QuestionCategory? questionCategory = await _questionCategoryRepository.GetAsync(predicate: qc => qc.Id == request.Id, cancellationToken: cancellationToken);
            await _questionCategoryBusinessRules.QuestionCategoryShouldExistWhenSelected(questionCategory);

            GetByIdQuestionCategoryResponse response = _mapper.Map<GetByIdQuestionCategoryResponse>(questionCategory);
            return response;
        }
    }
}