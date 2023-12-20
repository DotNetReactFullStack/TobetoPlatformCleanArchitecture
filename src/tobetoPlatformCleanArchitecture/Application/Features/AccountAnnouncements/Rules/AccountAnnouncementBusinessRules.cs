using Application.Features.AccountAnnouncements.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.AccountAnnouncements.Rules;

public class AccountAnnouncementBusinessRules : BaseBusinessRules
{
    private readonly IAccountAnnouncementRepository _accountAnnouncementRepository;

    public AccountAnnouncementBusinessRules(IAccountAnnouncementRepository accountAnnouncementRepository)
    {
        _accountAnnouncementRepository = accountAnnouncementRepository;
    }

    public Task AccountAnnouncementShouldExistWhenSelected(AccountAnnouncement? accountAnnouncement)
    {
        if (accountAnnouncement == null)
            throw new BusinessException(AccountAnnouncementsBusinessMessages.AccountAnnouncementNotExists);
        return Task.CompletedTask;
    }

    public async Task AccountAnnouncementIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        AccountAnnouncement? accountAnnouncement = await _accountAnnouncementRepository.GetAsync(
            predicate: aa => aa.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AccountAnnouncementShouldExistWhenSelected(accountAnnouncement);
    }
}