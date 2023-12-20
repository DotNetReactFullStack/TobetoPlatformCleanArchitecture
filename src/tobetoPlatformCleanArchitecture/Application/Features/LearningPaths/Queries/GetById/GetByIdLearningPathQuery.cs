using Application.Features.LearningPaths.Constants;
using Application.Features.LearningPaths.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.LearningPaths.Constants.LearningPathsOperationClaims;

namespace Application.Features.LearningPaths.Queries.GetById;

public class GetByIdLearningPathQuery : IRequest<GetByIdLearningPathResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdLearningPathQueryHandler : IRequestHandler<GetByIdLearningPathQuery, GetByIdLearningPathResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILearningPathRepository _learningPathRepository;
        private readonly LearningPathBusinessRules _learningPathBusinessRules;

        public GetByIdLearningPathQueryHandler(IMapper mapper, ILearningPathRepository learningPathRepository, LearningPathBusinessRules learningPathBusinessRules)
        {
            _mapper = mapper;
            _learningPathRepository = learningPathRepository;
            _learningPathBusinessRules = learningPathBusinessRules;
        }

        public async Task<GetByIdLearningPathResponse> Handle(GetByIdLearningPathQuery request, CancellationToken cancellationToken)
        {
            LearningPath? learningPath = await _learningPathRepository.GetAsync(predicate: lp => lp.Id == request.Id, cancellationToken: cancellationToken);
            await _learningPathBusinessRules.LearningPathShouldExistWhenSelected(learningPath);

            GetByIdLearningPathResponse response = _mapper.Map<GetByIdLearningPathResponse>(learningPath);
            return response;
        }
    }
}