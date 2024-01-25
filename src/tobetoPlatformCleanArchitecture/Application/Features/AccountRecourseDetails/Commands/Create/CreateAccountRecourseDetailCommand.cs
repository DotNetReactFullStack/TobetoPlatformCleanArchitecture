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

namespace Application.Features.AccountRecourseDetails.Commands.Create;

public class CreateAccountRecourseDetailCommand : IRequest<CreatedAccountRecourseDetailResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int AccountRecourseId { get; set; }
    public int RecourseDetailStepId { get; set; }
    public int RecourseDetailId { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountRecourseDetailsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountRecourseDetails";

    public class CreateAccountRecourseDetailCommandHandler : IRequestHandler<CreateAccountRecourseDetailCommand, CreatedAccountRecourseDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountRecourseDetailRepository _accountRecourseDetailRepository;
        private readonly AccountRecourseDetailBusinessRules _accountRecourseDetailBusinessRules;

        public CreateAccountRecourseDetailCommandHandler(IMapper mapper, IAccountRecourseDetailRepository accountRecourseDetailRepository,
                                         AccountRecourseDetailBusinessRules accountRecourseDetailBusinessRules)
        {
            _mapper = mapper;
            _accountRecourseDetailRepository = accountRecourseDetailRepository;
            _accountRecourseDetailBusinessRules = accountRecourseDetailBusinessRules;
        }

        public async Task<CreatedAccountRecourseDetailResponse> Handle(CreateAccountRecourseDetailCommand request, CancellationToken cancellationToken)
        {
            AccountRecourseDetail accountRecourseDetail = _mapper.Map<AccountRecourseDetail>(request);

            await _accountRecourseDetailRepository.AddAsync(accountRecourseDetail);

            CreatedAccountRecourseDetailResponse response = _mapper.Map<CreatedAccountRecourseDetailResponse>(accountRecourseDetail);
            return response;
        }
    }
}