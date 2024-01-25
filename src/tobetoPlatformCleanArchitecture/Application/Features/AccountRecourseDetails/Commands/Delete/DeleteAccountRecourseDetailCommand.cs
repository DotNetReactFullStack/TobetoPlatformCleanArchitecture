using Application.Features.AccountRecourseDetails.Constants;
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

namespace Application.Features.AccountRecourseDetails.Commands.Delete;

public class DeleteAccountRecourseDetailCommand : IRequest<DeletedAccountRecourseDetailResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountRecourseDetailsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountRecourseDetails";

    public class DeleteAccountRecourseDetailCommandHandler : IRequestHandler<DeleteAccountRecourseDetailCommand, DeletedAccountRecourseDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRecourseDetailRepository _accountRecourseDetailRepository;
        private readonly AccountRecourseDetailBusinessRules _accountRecourseDetailBusinessRules;

        public DeleteAccountRecourseDetailCommandHandler(IMapper mapper, IAccountRecourseDetailRepository accountRecourseDetailRepository,
                                         AccountRecourseDetailBusinessRules accountRecourseDetailBusinessRules)
        {
            _mapper = mapper;
            _accountRecourseDetailRepository = accountRecourseDetailRepository;
            _accountRecourseDetailBusinessRules = accountRecourseDetailBusinessRules;
        }

        public async Task<DeletedAccountRecourseDetailResponse> Handle(DeleteAccountRecourseDetailCommand request, CancellationToken cancellationToken)
        {
            AccountRecourseDetail? accountRecourseDetail = await _accountRecourseDetailRepository.GetAsync(predicate: ard => ard.Id == request.Id, cancellationToken: cancellationToken);
            await _accountRecourseDetailBusinessRules.AccountRecourseDetailShouldExistWhenSelected(accountRecourseDetail);

            await _accountRecourseDetailRepository.DeleteAsync(accountRecourseDetail!);

            DeletedAccountRecourseDetailResponse response = _mapper.Map<DeletedAccountRecourseDetailResponse>(accountRecourseDetail);
            return response;
        }
    }
}