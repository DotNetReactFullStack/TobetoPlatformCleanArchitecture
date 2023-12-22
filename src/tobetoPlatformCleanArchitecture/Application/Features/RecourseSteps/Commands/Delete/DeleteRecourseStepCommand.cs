using Application.Features.RecourseSteps.Constants;
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

namespace Application.Features.RecourseSteps.Commands.Delete;

public class DeleteRecourseStepCommand : IRequest<DeletedRecourseStepResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, RecourseStepsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetRecourseSteps";

    public class DeleteRecourseStepCommandHandler : IRequestHandler<DeleteRecourseStepCommand, DeletedRecourseStepResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRecourseStepRepository _recourseStepRepository;
        private readonly RecourseStepBusinessRules _recourseStepBusinessRules;

        public DeleteRecourseStepCommandHandler(IMapper mapper, IRecourseStepRepository recourseStepRepository,
                                         RecourseStepBusinessRules recourseStepBusinessRules)
        {
            _mapper = mapper;
            _recourseStepRepository = recourseStepRepository;
            _recourseStepBusinessRules = recourseStepBusinessRules;
        }

        public async Task<DeletedRecourseStepResponse> Handle(DeleteRecourseStepCommand request, CancellationToken cancellationToken)
        {
            RecourseStep? recourseStep = await _recourseStepRepository.GetAsync(predicate: rs => rs.Id == request.Id, cancellationToken: cancellationToken);
            await _recourseStepBusinessRules.RecourseStepShouldExistWhenSelected(recourseStep);

            await _recourseStepRepository.DeleteAsync(recourseStep!);

            DeletedRecourseStepResponse response = _mapper.Map<DeletedRecourseStepResponse>(recourseStep);
            return response;
        }
    }
}