using Application.Features.AccountAnnouncements.Constants;
using Application.Features.AccountAnnouncements.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.AccountAnnouncements.Constants.AccountAnnouncementsOperationClaims;

namespace Application.Features.AccountAnnouncements.Commands.Create;

public class CreateAccountAnnouncementCommand : IRequest<CreatedAccountAnnouncementResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int AccountId { get; set; }
    public int AnnouncementId { get; set; }
    public bool Read { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountAnnouncementsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountAnnouncements";

    public class CreateAccountAnnouncementCommandHandler : IRequestHandler<CreateAccountAnnouncementCommand, CreatedAccountAnnouncementResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountAnnouncementRepository _accountAnnouncementRepository;
        private readonly AccountAnnouncementBusinessRules _accountAnnouncementBusinessRules;

        public CreateAccountAnnouncementCommandHandler(IMapper mapper, IAccountAnnouncementRepository accountAnnouncementRepository,
                                         AccountAnnouncementBusinessRules accountAnnouncementBusinessRules)
        {
            _mapper = mapper;
            _accountAnnouncementRepository = accountAnnouncementRepository;
            _accountAnnouncementBusinessRules = accountAnnouncementBusinessRules;
        }

        public async Task<CreatedAccountAnnouncementResponse> Handle(CreateAccountAnnouncementCommand request, CancellationToken cancellationToken)
        {
            AccountAnnouncement accountAnnouncement = _mapper.Map<AccountAnnouncement>(request);

            await _accountAnnouncementRepository.AddAsync(accountAnnouncement);

            CreatedAccountAnnouncementResponse response = _mapper.Map<CreatedAccountAnnouncementResponse>(accountAnnouncement);
            return response;
        }
    }
}