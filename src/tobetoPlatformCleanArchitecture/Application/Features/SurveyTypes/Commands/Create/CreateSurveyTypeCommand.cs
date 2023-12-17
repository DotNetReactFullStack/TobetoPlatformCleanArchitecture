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

namespace Application.Features.SurveyTypes.Commands.Create;

public class CreateSurveyTypeCommand : IRequest<CreatedSurveyTypeResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, SurveyTypesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSurveyTypes";

    public class CreateSurveyTypeCommandHandler : IRequestHandler<CreateSurveyTypeCommand, CreatedSurveyTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISurveyTypeRepository _surveyTypeRepository;
        private readonly SurveyTypeBusinessRules _surveyTypeBusinessRules;

        public CreateSurveyTypeCommandHandler(IMapper mapper, ISurveyTypeRepository surveyTypeRepository,
                                         SurveyTypeBusinessRules surveyTypeBusinessRules)
        {
            _mapper = mapper;
            _surveyTypeRepository = surveyTypeRepository;
            _surveyTypeBusinessRules = surveyTypeBusinessRules;
        }

        public async Task<CreatedSurveyTypeResponse> Handle(CreateSurveyTypeCommand request, CancellationToken cancellationToken)
        {
            SurveyType surveyType = _mapper.Map<SurveyType>(request);

            await _surveyTypeRepository.AddAsync(surveyType);

            CreatedSurveyTypeResponse response = _mapper.Map<CreatedSurveyTypeResponse>(surveyType);
            return response;
        }
    }
}