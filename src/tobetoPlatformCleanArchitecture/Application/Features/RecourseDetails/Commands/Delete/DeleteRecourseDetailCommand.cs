using Application.Features.RecourseDetails.Constants;
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

namespace Application.Features.RecourseDetails.Commands.Delete;

public class DeleteRecourseDetailCommand : IRequest<DeletedRecourseDetailResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, RecourseDetailsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetRecourseDetails";

    public class DeleteRecourseDetailCommandHandler : IRequestHandler<DeleteRecourseDetailCommand, DeletedRecourseDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRecourseDetailRepository _recourseDetailRepository;
        private readonly RecourseDetailBusinessRules _recourseDetailBusinessRules;

        public DeleteRecourseDetailCommandHandler(IMapper mapper, IRecourseDetailRepository recourseDetailRepository,
                                         RecourseDetailBusinessRules recourseDetailBusinessRules)
        {
            _mapper = mapper;
            _recourseDetailRepository = recourseDetailRepository;
            _recourseDetailBusinessRules = recourseDetailBusinessRules;
        }

        public async Task<DeletedRecourseDetailResponse> Handle(DeleteRecourseDetailCommand request, CancellationToken cancellationToken)
        {
            RecourseDetail? recourseDetail = await _recourseDetailRepository.GetAsync(predicate: rd => rd.Id == request.Id, cancellationToken: cancellationToken);
            await _recourseDetailBusinessRules.RecourseDetailShouldExistWhenSelected(recourseDetail);

            await _recourseDetailRepository.DeleteAsync(recourseDetail!);

            DeletedRecourseDetailResponse response = _mapper.Map<DeletedRecourseDetailResponse>(recourseDetail);
            return response;
        }
    }
}