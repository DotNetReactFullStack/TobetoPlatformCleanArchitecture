using Application.Features.RecourseSteps.Constants;
using Application.Features.RecourseSteps.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.RecourseSteps.Constants.RecourseStepsOperationClaims;

namespace Application.Features.RecourseSteps.Commands.Update;

public class UpdateRecourseStepCommand : IRequest<UpdatedRecourseStepResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, RecourseStepsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetRecourseSteps";

    public class UpdateRecourseStepCommandHandler : IRequestHandler<UpdateRecourseStepCommand, UpdatedRecourseStepResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRecourseStepRepository _recourseStepRepository;
        private readonly RecourseStepBusinessRules _recourseStepBusinessRules;

        public UpdateRecourseStepCommandHandler(IMapper mapper, IRecourseStepRepository recourseStepRepository,
                                         RecourseStepBusinessRules recourseStepBusinessRules)
        {
            _mapper = mapper;
            _recourseStepRepository = recourseStepRepository;
            _recourseStepBusinessRules = recourseStepBusinessRules;
        }

        public async Task<UpdatedRecourseStepResponse> Handle(UpdateRecourseStepCommand request, CancellationToken cancellationToken)
        {
            RecourseStep? recourseStep = await _recourseStepRepository.GetAsync(predicate: rs => rs.Id == request.Id, cancellationToken: cancellationToken);
            await _recourseStepBusinessRules.RecourseStepShouldExistWhenSelected(recourseStep);
            recourseStep = _mapper.Map(request, recourseStep);

            await _recourseStepRepository.UpdateAsync(recourseStep!);

            UpdatedRecourseStepResponse response = _mapper.Map<UpdatedRecourseStepResponse>(recourseStep);
            return response;
        }
    }
}