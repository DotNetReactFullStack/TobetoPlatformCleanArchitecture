using Application.Features.SurveyTypes.Constants;
using Application.Features.SurveyTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.SurveyTypes.Constants.SurveyTypesOperationClaims;

namespace Application.Features.SurveyTypes.Commands.Update;

public class UpdateSurveyTypeCommand : IRequest<UpdatedSurveyTypeResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, SurveyTypesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSurveyTypes";

    public class UpdateSurveyTypeCommandHandler : IRequestHandler<UpdateSurveyTypeCommand, UpdatedSurveyTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISurveyTypeRepository _surveyTypeRepository;
        private readonly SurveyTypeBusinessRules _surveyTypeBusinessRules;

        public UpdateSurveyTypeCommandHandler(IMapper mapper, ISurveyTypeRepository surveyTypeRepository,
                                         SurveyTypeBusinessRules surveyTypeBusinessRules)
        {
            _mapper = mapper;
            _surveyTypeRepository = surveyTypeRepository;
            _surveyTypeBusinessRules = surveyTypeBusinessRules;
        }

        public async Task<UpdatedSurveyTypeResponse> Handle(UpdateSurveyTypeCommand request, CancellationToken cancellationToken)
        {
            SurveyType? surveyType = await _surveyTypeRepository.GetAsync(predicate: st => st.Id == request.Id, cancellationToken: cancellationToken);
            await _surveyTypeBusinessRules.SurveyTypeShouldExistWhenSelected(surveyType);
            surveyType = _mapper.Map(request, surveyType);

            await _surveyTypeRepository.UpdateAsync(surveyType!);

            UpdatedSurveyTypeResponse response = _mapper.Map<UpdatedSurveyTypeResponse>(surveyType);
            return response;
        }
    }
}