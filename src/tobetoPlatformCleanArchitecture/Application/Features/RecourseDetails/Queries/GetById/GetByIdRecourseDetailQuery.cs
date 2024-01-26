using Application.Features.RecourseDetails.Constants;
using Application.Features.RecourseDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.RecourseDetails.Constants.RecourseDetailsOperationClaims;

namespace Application.Features.RecourseDetails.Queries.GetById;

public class GetByIdRecourseDetailQuery : IRequest<GetByIdRecourseDetailResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdRecourseDetailQueryHandler : IRequestHandler<GetByIdRecourseDetailQuery, GetByIdRecourseDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRecourseDetailRepository _recourseDetailRepository;
        private readonly RecourseDetailBusinessRules _recourseDetailBusinessRules;

        public GetByIdRecourseDetailQueryHandler(IMapper mapper, IRecourseDetailRepository recourseDetailRepository, RecourseDetailBusinessRules recourseDetailBusinessRules)
        {
            _mapper = mapper;
            _recourseDetailRepository = recourseDetailRepository;
            _recourseDetailBusinessRules = recourseDetailBusinessRules;
        }

        public async Task<GetByIdRecourseDetailResponse> Handle(GetByIdRecourseDetailQuery request, CancellationToken cancellationToken)
        {
            RecourseDetail? recourseDetail = await _recourseDetailRepository.GetAsync(predicate: rd => rd.Id == request.Id, cancellationToken: cancellationToken);
            await _recourseDetailBusinessRules.RecourseDetailShouldExistWhenSelected(recourseDetail);

            GetByIdRecourseDetailResponse response = _mapper.Map<GetByIdRecourseDetailResponse>(recourseDetail);
            return response;
        }
    }
}