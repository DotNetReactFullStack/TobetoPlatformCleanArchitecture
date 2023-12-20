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

namespace Application.Features.AccountAnnouncements.Commands.Update;

public class UpdateAccountAnnouncementCommand : IRequest<UpdatedAccountAnnouncementResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int AnnouncementId { get; set; }
    public bool Read { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountAnnouncementsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountAnnouncements";

    public class UpdateAccountAnnouncementCommandHandler : IRequestHandler<UpdateAccountAnnouncementCommand, UpdatedAccountAnnouncementResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountAnnouncementRepository _accountAnnouncementRepository;
        private readonly AccountAnnouncementBusinessRules _accountAnnouncementBusinessRules;

        public UpdateAccountAnnouncementCommandHandler(IMapper mapper, IAccountAnnouncementRepository accountAnnouncementRepository,
                                         AccountAnnouncementBusinessRules accountAnnouncementBusinessRules)
        {
            _mapper = mapper;
            _accountAnnouncementRepository = accountAnnouncementRepository;
            _accountAnnouncementBusinessRules = accountAnnouncementBusinessRules;
        }

        public async Task<UpdatedAccountAnnouncementResponse> Handle(UpdateAccountAnnouncementCommand request, CancellationToken cancellationToken)
        {
            AccountAnnouncement? accountAnnouncement = await _accountAnnouncementRepository.GetAsync(predicate: aa => aa.Id == request.Id, cancellationToken: cancellationToken);
            await _accountAnnouncementBusinessRules.AccountAnnouncementShouldExistWhenSelected(accountAnnouncement);
            accountAnnouncement = _mapper.Map(request, accountAnnouncement);

            await _accountAnnouncementRepository.UpdateAsync(accountAnnouncement!);

            UpdatedAccountAnnouncementResponse response = _mapper.Map<UpdatedAccountAnnouncementResponse>(accountAnnouncement);
            return response;
        }
    }
}