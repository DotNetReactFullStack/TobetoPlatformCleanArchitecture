using Application.Features.AccountAnnouncements.Constants;
using Application.Features.AccountAnnouncements.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AccountAnnouncements.Constants.AccountAnnouncementsOperationClaims;

namespace Application.Features.AccountAnnouncements.Queries.GetById;

public class GetByIdAccountAnnouncementQuery : IRequest<GetByIdAccountAnnouncementResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdAccountAnnouncementQueryHandler : IRequestHandler<GetByIdAccountAnnouncementQuery, GetByIdAccountAnnouncementResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAccountAnnouncementRepository _accountAnnouncementRepository;
        private readonly AccountAnnouncementBusinessRules _accountAnnouncementBusinessRules;

        public GetByIdAccountAnnouncementQueryHandler(IMapper mapper, IAccountAnnouncementRepository accountAnnouncementRepository, AccountAnnouncementBusinessRules accountAnnouncementBusinessRules)
        {
            _mapper = mapper;
            _accountAnnouncementRepository = accountAnnouncementRepository;
            _accountAnnouncementBusinessRules = accountAnnouncementBusinessRules;
        }

        public async Task<GetByIdAccountAnnouncementResponse> Handle(GetByIdAccountAnnouncementQuery request, CancellationToken cancellationToken)
        {
            AccountAnnouncement? accountAnnouncement = await _accountAnnouncementRepository.GetAsync(predicate: aa => aa.Id == request.Id, cancellationToken: cancellationToken);
            await _accountAnnouncementBusinessRules.AccountAnnouncementShouldExistWhenSelected(accountAnnouncement);

            GetByIdAccountAnnouncementResponse response = _mapper.Map<GetByIdAccountAnnouncementResponse>(accountAnnouncement);
            return response;
        }
    }
}