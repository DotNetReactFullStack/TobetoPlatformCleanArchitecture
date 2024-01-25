using Application.Features.RecourseDetailSteps.Constants;
using Application.Features.RecourseDetailSteps.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.RecourseDetailSteps.Constants.RecourseDetailStepsOperationClaims;

namespace Application.Features.RecourseDetailSteps.Commands.Update;

public class UpdateRecourseDetailStepCommand : IRequest<UpdatedRecourseDetailStepResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Priority { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, RecourseDetailStepsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetRecourseDetailSteps";

    public class UpdateRecourseDetailStepCommandHandler : IRequestHandler<UpdateRecourseDetailStepCommand, UpdatedRecourseDetailStepResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRecourseDetailStepRepository _recourseDetailStepRepository;
        private readonly RecourseDetailStepBusinessRules _recourseDetailStepBusinessRules;

        public UpdateRecourseDetailStepCommandHandler(IMapper mapper, IRecourseDetailStepRepository recourseDetailStepRepository,
                                         RecourseDetailStepBusinessRules recourseDetailStepBusinessRules)
        {
            _mapper = mapper;
            _recourseDetailStepRepository = recourseDetailStepRepository;
            _recourseDetailStepBusinessRules = recourseDetailStepBusinessRules;
        }

        public async Task<UpdatedRecourseDetailStepResponse> Handle(UpdateRecourseDetailStepCommand request, CancellationToken cancellationToken)
        {
            RecourseDetailStep? recourseDetailStep = await _recourseDetailStepRepository.GetAsync(predicate: rds => rds.Id == request.Id, cancellationToken: cancellationToken);
            await _recourseDetailStepBusinessRules.RecourseDetailStepShouldExistWhenSelected(recourseDetailStep);
            recourseDetailStep = _mapper.Map(request, recourseDetailStep);

            await _recourseDetailStepRepository.UpdateAsync(recourseDetailStep!);

            UpdatedRecourseDetailStepResponse response = _mapper.Map<UpdatedRecourseDetailStepResponse>(recourseDetailStep);
            return response;
        }
    }
}