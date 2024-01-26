using Application.Features.AccountRecourseDetails.Constants;
using Application.Features.AccountRecourseDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.AccountRecourseDetails.Constants.AccountRecourseDetailsOperationClaims;

namespace Application.Features.AccountRecourseDetails.Commands.Update;

public class UpdateAccountRecourseDetailCommand : IRequest<UpdatedAccountRecourseDetailResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int AccountRecourseId { get; set; }
    public int RecourseDetailStepId { get; set; }
    public int RecourseDetailId { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountRecourseDetailsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountRecourseDetails";

    public class UpdateAccountRecourseDetailCommandHandler : IRequestHandler<UpdateAccountRecourseDetailCommand, UpdatedAccountRecourseDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRecourseDetailRepository _accountRecourseDetailRepository;
        private readonly AccountRecourseDetailBusinessRules _accountRecourseDetailBusinessRules;

        public UpdateAccountRecourseDetailCommandHandler(IMapper mapper, IAccountRecourseDetailRepository accountRecourseDetailRepository,
                                         AccountRecourseDetailBusinessRules accountRecourseDetailBusinessRules)
        {
            _mapper = mapper;
            _accountRecourseDetailRepository = accountRecourseDetailRepository;
            _accountRecourseDetailBusinessRules = accountRecourseDetailBusinessRules;
        }

        public async Task<UpdatedAccountRecourseDetailResponse> Handle(UpdateAccountRecourseDetailCommand request, CancellationToken cancellationToken)
        {
            AccountRecourseDetail? accountRecourseDetail = await _accountRecourseDetailRepository.GetAsync(predicate: ard => ard.Id == request.Id, cancellationToken: cancellationToken);
            await _accountRecourseDetailBusinessRules.AccountRecourseDetailShouldExistWhenSelected(accountRecourseDetail);
            accountRecourseDetail = _mapper.Map(request, accountRecourseDetail);

            await _accountRecourseDetailRepository.UpdateAsync(accountRecourseDetail!);

            UpdatedAccountRecourseDetailResponse response = _mapper.Map<UpdatedAccountRecourseDetailResponse>(accountRecourseDetail);
            return response;
        }
    }
}