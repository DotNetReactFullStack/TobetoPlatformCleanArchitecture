using Application.Features.AccountAnnouncements.Constants;
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

namespace Application.Features.AccountAnnouncements.Commands.Delete;

public class DeleteAccountAnnouncementCommand : IRequest<DeletedAccountAnnouncementResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, AccountAnnouncementsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAccountAnnouncements";

    public class DeleteAccountAnnouncementCommandHandler : IRequestHandler<DeleteAccountAnnouncementCommand, DeletedAccountAnnouncementResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountAnnouncementRepository _accountAnnouncementRepository;
        private readonly AccountAnnouncementBusinessRules _accountAnnouncementBusinessRules;

        public DeleteAccountAnnouncementCommandHandler(IMapper mapper, IAccountAnnouncementRepository accountAnnouncementRepository,
                                         AccountAnnouncementBusinessRules accountAnnouncementBusinessRules)
        {
            _mapper = mapper;
            _accountAnnouncementRepository = accountAnnouncementRepository;
            _accountAnnouncementBusinessRules = accountAnnouncementBusinessRules;
        }

        public async Task<DeletedAccountAnnouncementResponse> Handle(DeleteAccountAnnouncementCommand request, CancellationToken cancellationToken)
        {
            AccountAnnouncement? accountAnnouncement = await _accountAnnouncementRepository.GetAsync(predicate: aa => aa.Id == request.Id, cancellationToken: cancellationToken);
            await _accountAnnouncementBusinessRules.AccountAnnouncementShouldExistWhenSelected(accountAnnouncement);

            await _accountAnnouncementRepository.DeleteAsync(accountAnnouncement!);

            DeletedAccountAnnouncementResponse response = _mapper.Map<DeletedAccountAnnouncementResponse>(accountAnnouncement);
            return response;
        }
    }
}