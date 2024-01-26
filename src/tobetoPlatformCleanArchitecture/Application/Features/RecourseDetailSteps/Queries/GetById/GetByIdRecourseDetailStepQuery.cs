using Application.Features.RecourseDetailSteps.Constants;
using Application.Features.RecourseDetailSteps.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.RecourseDetailSteps.Constants.RecourseDetailStepsOperationClaims;

namespace Application.Features.RecourseDetailSteps.Queries.GetById;

public class GetByIdRecourseDetailStepQuery : IRequest<GetByIdRecourseDetailStepResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdRecourseDetailStepQueryHandler : IRequestHandler<GetByIdRecourseDetailStepQuery, GetByIdRecourseDetailStepResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRecourseDetailStepRepository _recourseDetailStepRepository;
        private readonly RecourseDetailStepBusinessRules _recourseDetailStepBusinessRules;

        public GetByIdRecourseDetailStepQueryHandler(IMapper mapper, IRecourseDetailStepRepository recourseDetailStepRepository, RecourseDetailStepBusinessRules recourseDetailStepBusinessRules)
        {
            _mapper = mapper;
            _recourseDetailStepRepository = recourseDetailStepRepository;
            _recourseDetailStepBusinessRules = recourseDetailStepBusinessRules;
        }

        public async Task<GetByIdRecourseDetailStepResponse> Handle(GetByIdRecourseDetailStepQuery request, CancellationToken cancellationToken)
        {
            RecourseDetailStep? recourseDetailStep = await _recourseDetailStepRepository.GetAsync(predicate: rds => rds.Id == request.Id, cancellationToken: cancellationToken);
            await _recourseDetailStepBusinessRules.RecourseDetailStepShouldExistWhenSelected(recourseDetailStep);

            GetByIdRecourseDetailStepResponse response = _mapper.Map<GetByIdRecourseDetailStepResponse>(recourseDetailStep);
            return response;
        }
    }
}