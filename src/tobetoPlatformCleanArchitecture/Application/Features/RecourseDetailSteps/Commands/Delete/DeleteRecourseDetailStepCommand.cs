using Application.Features.RecourseDetailSteps.Constants;
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

namespace Application.Features.RecourseDetailSteps.Commands.Delete;

public class DeleteRecourseDetailStepCommand : IRequest<DeletedRecourseDetailStepResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, RecourseDetailStepsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetRecourseDetailSteps";

    public class DeleteRecourseDetailStepCommandHandler : IRequestHandler<DeleteRecourseDetailStepCommand, DeletedRecourseDetailStepResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRecourseDetailStepRepository _recourseDetailStepRepository;
        private readonly RecourseDetailStepBusinessRules _recourseDetailStepBusinessRules;

        public DeleteRecourseDetailStepCommandHandler(IMapper mapper, IRecourseDetailStepRepository recourseDetailStepRepository,
                                         RecourseDetailStepBusinessRules recourseDetailStepBusinessRules)
        {
            _mapper = mapper;
            _recourseDetailStepRepository = recourseDetailStepRepository;
            _recourseDetailStepBusinessRules = recourseDetailStepBusinessRules;
        }

        public async Task<DeletedRecourseDetailStepResponse> Handle(DeleteRecourseDetailStepCommand request, CancellationToken cancellationToken)
        {
            RecourseDetailStep? recourseDetailStep = await _recourseDetailStepRepository.GetAsync(predicate: rds => rds.Id == request.Id, cancellationToken: cancellationToken);
            await _recourseDetailStepBusinessRules.RecourseDetailStepShouldExistWhenSelected(recourseDetailStep);

            await _recourseDetailStepRepository.DeleteAsync(recourseDetailStep!);

            DeletedRecourseDetailStepResponse response = _mapper.Map<DeletedRecourseDetailStepResponse>(recourseDetailStep);
            return response;
        }
    }
}