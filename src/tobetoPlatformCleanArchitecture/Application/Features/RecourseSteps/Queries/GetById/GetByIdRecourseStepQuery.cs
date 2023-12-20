using Application.Features.RecourseSteps.Constants;
using Application.Features.RecourseSteps.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.RecourseSteps.Constants.RecourseStepsOperationClaims;

namespace Application.Features.RecourseSteps.Queries.GetById;

public class GetByIdRecourseStepQuery : IRequest<GetByIdRecourseStepResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdRecourseStepQueryHandler : IRequestHandler<GetByIdRecourseStepQuery, GetByIdRecourseStepResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRecourseStepRepository _recourseStepRepository;
        private readonly RecourseStepBusinessRules _recourseStepBusinessRules;

        public GetByIdRecourseStepQueryHandler(IMapper mapper, IRecourseStepRepository recourseStepRepository, RecourseStepBusinessRules recourseStepBusinessRules)
        {
            _mapper = mapper;
            _recourseStepRepository = recourseStepRepository;
            _recourseStepBusinessRules = recourseStepBusinessRules;
        }

        public async Task<GetByIdRecourseStepResponse> Handle(GetByIdRecourseStepQuery request, CancellationToken cancellationToken)
        {
            RecourseStep? recourseStep = await _recourseStepRepository.GetAsync(predicate: rs => rs.Id == request.Id, cancellationToken: cancellationToken);
            await _recourseStepBusinessRules.RecourseStepShouldExistWhenSelected(recourseStep);

            GetByIdRecourseStepResponse response = _mapper.Map<GetByIdRecourseStepResponse>(recourseStep);
            return response;
        }
    }
}