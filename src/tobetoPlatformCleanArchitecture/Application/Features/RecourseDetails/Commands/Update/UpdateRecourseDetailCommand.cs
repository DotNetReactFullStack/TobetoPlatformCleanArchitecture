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

namespace Application.Features.RecourseDetails.Commands.Update;

public class UpdateRecourseDetailCommand : IRequest<UpdatedRecourseDetailResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Priority { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, RecourseDetailsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetRecourseDetails";

    public class UpdateRecourseDetailCommandHandler : IRequestHandler<UpdateRecourseDetailCommand, UpdatedRecourseDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRecourseDetailRepository _recourseDetailRepository;
        private readonly RecourseDetailBusinessRules _recourseDetailBusinessRules;

        public UpdateRecourseDetailCommandHandler(IMapper mapper, IRecourseDetailRepository recourseDetailRepository,
                                         RecourseDetailBusinessRules recourseDetailBusinessRules)
        {
            _mapper = mapper;
            _recourseDetailRepository = recourseDetailRepository;
            _recourseDetailBusinessRules = recourseDetailBusinessRules;
        }

        public async Task<UpdatedRecourseDetailResponse> Handle(UpdateRecourseDetailCommand request, CancellationToken cancellationToken)
        {
            RecourseDetail? recourseDetail = await _recourseDetailRepository.GetAsync(predicate: rd => rd.Id == request.Id, cancellationToken: cancellationToken);
            await _recourseDetailBusinessRules.RecourseDetailShouldExistWhenSelected(recourseDetail);
            recourseDetail = _mapper.Map(request, recourseDetail);

            await _recourseDetailRepository.UpdateAsync(recourseDetail!);

            UpdatedRecourseDetailResponse response = _mapper.Map<UpdatedRecourseDetailResponse>(recourseDetail);
            return response;
        }
    }
}