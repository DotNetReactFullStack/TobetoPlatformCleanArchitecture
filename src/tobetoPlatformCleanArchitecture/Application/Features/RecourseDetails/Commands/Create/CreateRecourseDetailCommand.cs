using Application.Features.RecourseDetails.Constants;
using Application.Features.RecourseDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.RecourseDetails.Constants.RecourseDetailsOperationClaims;

namespace Application.Features.RecourseDetails.Commands.Create;

public class CreateRecourseDetailCommand : IRequest<CreatedRecourseDetailResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public string Priority { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, RecourseDetailsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetRecourseDetails";

    public class CreateRecourseDetailCommandHandler : IRequestHandler<CreateRecourseDetailCommand, CreatedRecourseDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRecourseDetailRepository _recourseDetailRepository;
        private readonly RecourseDetailBusinessRules _recourseDetailBusinessRules;

        public CreateRecourseDetailCommandHandler(IMapper mapper, IRecourseDetailRepository recourseDetailRepository,
                                         RecourseDetailBusinessRules recourseDetailBusinessRules)
        {
            _mapper = mapper;
            _recourseDetailRepository = recourseDetailRepository;
            _recourseDetailBusinessRules = recourseDetailBusinessRules;
        }

        public async Task<CreatedRecourseDetailResponse> Handle(CreateRecourseDetailCommand request, CancellationToken cancellationToken)
        {
            RecourseDetail recourseDetail = _mapper.Map<RecourseDetail>(request);

            await _recourseDetailRepository.AddAsync(recourseDetail);

            CreatedRecourseDetailResponse response = _mapper.Map<CreatedRecourseDetailResponse>(recourseDetail);
            return response;
        }
    }
}