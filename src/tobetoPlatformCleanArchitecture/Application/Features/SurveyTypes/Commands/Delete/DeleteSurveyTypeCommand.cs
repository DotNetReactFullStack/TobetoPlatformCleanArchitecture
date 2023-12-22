using Application.Features.SurveyTypes.Constants;
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

namespace Application.Features.SurveyTypes.Commands.Delete;

public class DeleteSurveyTypeCommand : IRequest<DeletedSurveyTypeResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, SurveyTypesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSurveyTypes";

    public class DeleteSurveyTypeCommandHandler : IRequestHandler<DeleteSurveyTypeCommand, DeletedSurveyTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISurveyTypeRepository _surveyTypeRepository;
        private readonly SurveyTypeBusinessRules _surveyTypeBusinessRules;

        public DeleteSurveyTypeCommandHandler(IMapper mapper, ISurveyTypeRepository surveyTypeRepository,
                                         SurveyTypeBusinessRules surveyTypeBusinessRules)
        {
            _mapper = mapper;
            _surveyTypeRepository = surveyTypeRepository;
            _surveyTypeBusinessRules = surveyTypeBusinessRules;
        }

        public async Task<DeletedSurveyTypeResponse> Handle(DeleteSurveyTypeCommand request, CancellationToken cancellationToken)
        {
            SurveyType? surveyType = await _surveyTypeRepository.GetAsync(predicate: st => st.Id == request.Id, cancellationToken: cancellationToken);
            await _surveyTypeBusinessRules.SurveyTypeShouldExistWhenSelected(surveyType);

            await _surveyTypeRepository.DeleteAsync(surveyType!);

            DeletedSurveyTypeResponse response = _mapper.Map<DeletedSurveyTypeResponse>(surveyType);
            return response;
        }
    }
}