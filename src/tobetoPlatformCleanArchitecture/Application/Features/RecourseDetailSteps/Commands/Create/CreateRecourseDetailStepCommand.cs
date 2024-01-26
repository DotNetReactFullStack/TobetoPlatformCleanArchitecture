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

namespace Application.Features.RecourseDetailSteps.Commands.Create;

public class CreateRecourseDetailStepCommand : IRequest<CreatedRecourseDetailStepResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public string Priority { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, RecourseDetailStepsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetRecourseDetailSteps";

    public class CreateRecourseDetailStepCommandHandler : IRequestHandler<CreateRecourseDetailStepCommand, CreatedRecourseDetailStepResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRecourseDetailStepRepository _recourseDetailStepRepository;
        private readonly RecourseDetailStepBusinessRules _recourseDetailStepBusinessRules;

        public CreateRecourseDetailStepCommandHandler(IMapper mapper, IRecourseDetailStepRepository recourseDetailStepRepository,
                                         RecourseDetailStepBusinessRules recourseDetailStepBusinessRules)
        {
            _mapper = mapper;
            _recourseDetailStepRepository = recourseDetailStepRepository;
            _recourseDetailStepBusinessRules = recourseDetailStepBusinessRules;
        }

        public async Task<CreatedRecourseDetailStepResponse> Handle(CreateRecourseDetailStepCommand request, CancellationToken cancellationToken)
        {
            RecourseDetailStep recourseDetailStep = _mapper.Map<RecourseDetailStep>(request);

            await _recourseDetailStepRepository.AddAsync(recourseDetailStep);

            CreatedRecourseDetailStepResponse response = _mapper.Map<CreatedRecourseDetailStepResponse>(recourseDetailStep);
            return response;
        }
    }
}