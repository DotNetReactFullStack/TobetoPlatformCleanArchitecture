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

namespace Application.Features.RecourseSteps.Commands.Create;

public class CreateRecourseStepCommand : IRequest<CreatedRecourseStepResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, RecourseStepsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetRecourseSteps";

    public class CreateRecourseStepCommandHandler : IRequestHandler<CreateRecourseStepCommand, CreatedRecourseStepResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRecourseStepRepository _recourseStepRepository;
        private readonly RecourseStepBusinessRules _recourseStepBusinessRules;

        public CreateRecourseStepCommandHandler(IMapper mapper, IRecourseStepRepository recourseStepRepository,
                                         RecourseStepBusinessRules recourseStepBusinessRules)
        {
            _mapper = mapper;
            _recourseStepRepository = recourseStepRepository;
            _recourseStepBusinessRules = recourseStepBusinessRules;
        }

        public async Task<CreatedRecourseStepResponse> Handle(CreateRecourseStepCommand request, CancellationToken cancellationToken)
        {
            RecourseStep recourseStep = _mapper.Map<RecourseStep>(request);

            await _recourseStepRepository.AddAsync(recourseStep);

            CreatedRecourseStepResponse response = _mapper.Map<CreatedRecourseStepResponse>(recourseStep);
            return response;
        }
    }
}