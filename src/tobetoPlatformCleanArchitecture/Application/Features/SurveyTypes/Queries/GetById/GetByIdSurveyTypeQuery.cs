using Application.Features.SurveyTypes.Constants;
using Application.Features.SurveyTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.SurveyTypes.Constants.SurveyTypesOperationClaims;

namespace Application.Features.SurveyTypes.Queries.GetById;

public class GetByIdSurveyTypeQuery : IRequest<GetByIdSurveyTypeResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdSurveyTypeQueryHandler : IRequestHandler<GetByIdSurveyTypeQuery, GetByIdSurveyTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISurveyTypeRepository _surveyTypeRepository;
        private readonly SurveyTypeBusinessRules _surveyTypeBusinessRules;

        public GetByIdSurveyTypeQueryHandler(IMapper mapper, ISurveyTypeRepository surveyTypeRepository, SurveyTypeBusinessRules surveyTypeBusinessRules)
        {
            _mapper = mapper;
            _surveyTypeRepository = surveyTypeRepository;
            _surveyTypeBusinessRules = surveyTypeBusinessRules;
        }

        public async Task<GetByIdSurveyTypeResponse> Handle(GetByIdSurveyTypeQuery request, CancellationToken cancellationToken)
        {
            SurveyType? surveyType = await _surveyTypeRepository.GetAsync(predicate: st => st.Id == request.Id, cancellationToken: cancellationToken);
            await _surveyTypeBusinessRules.SurveyTypeShouldExistWhenSelected(surveyType);

            GetByIdSurveyTypeResponse response = _mapper.Map<GetByIdSurveyTypeResponse>(surveyType);
            return response;
        }
    }
}