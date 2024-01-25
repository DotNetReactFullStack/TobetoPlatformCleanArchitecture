using Application.Features.AccountRecourseDetails.Constants;
using Application.Features.AccountRecourseDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AccountRecourseDetails.Constants.AccountRecourseDetailsOperationClaims;

namespace Application.Features.AccountRecourseDetails.Queries.GetById;

public class GetByIdAccountRecourseDetailQuery : IRequest<GetByIdAccountRecourseDetailResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdAccountRecourseDetailQueryHandler : IRequestHandler<GetByIdAccountRecourseDetailQuery, GetByIdAccountRecourseDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRecourseDetailRepository _accountRecourseDetailRepository;
        private readonly AccountRecourseDetailBusinessRules _accountRecourseDetailBusinessRules;

        public GetByIdAccountRecourseDetailQueryHandler(IMapper mapper, IAccountRecourseDetailRepository accountRecourseDetailRepository, AccountRecourseDetailBusinessRules accountRecourseDetailBusinessRules)
        {
            _mapper = mapper;
            _accountRecourseDetailRepository = accountRecourseDetailRepository;
            _accountRecourseDetailBusinessRules = accountRecourseDetailBusinessRules;
        }

        public async Task<GetByIdAccountRecourseDetailResponse> Handle(GetByIdAccountRecourseDetailQuery request, CancellationToken cancellationToken)
        {
            AccountRecourseDetail? accountRecourseDetail = await _accountRecourseDetailRepository.GetAsync(predicate: ard => ard.Id == request.Id, cancellationToken: cancellationToken);
            await _accountRecourseDetailBusinessRules.AccountRecourseDetailShouldExistWhenSelected(accountRecourseDetail);

            GetByIdAccountRecourseDetailResponse response = _mapper.Map<GetByIdAccountRecourseDetailResponse>(accountRecourseDetail);
            return response;
        }
    }
}