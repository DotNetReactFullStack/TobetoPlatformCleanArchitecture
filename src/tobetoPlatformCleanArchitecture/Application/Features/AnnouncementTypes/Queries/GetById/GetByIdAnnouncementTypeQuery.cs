using Application.Features.AnnouncementTypes.Constants;
using Application.Features.AnnouncementTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AnnouncementTypes.Constants.AnnouncementTypesOperationClaims;

namespace Application.Features.AnnouncementTypes.Queries.GetById;

public class GetByIdAnnouncementTypeQuery : IRequest<GetByIdAnnouncementTypeResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdAnnouncementTypeQueryHandler : IRequestHandler<GetByIdAnnouncementTypeQuery, GetByIdAnnouncementTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAnnouncementTypeRepository _announcementTypeRepository;
        private readonly AnnouncementTypeBusinessRules _announcementTypeBusinessRules;

        public GetByIdAnnouncementTypeQueryHandler(IMapper mapper, IAnnouncementTypeRepository announcementTypeRepository, AnnouncementTypeBusinessRules announcementTypeBusinessRules)
        {
            _mapper = mapper;
            _announcementTypeRepository = announcementTypeRepository;
            _announcementTypeBusinessRules = announcementTypeBusinessRules;
        }

        public async Task<GetByIdAnnouncementTypeResponse> Handle(GetByIdAnnouncementTypeQuery request, CancellationToken cancellationToken)
        {
            AnnouncementType? announcementType = await _announcementTypeRepository.GetAsync(predicate: at => at.Id == request.Id, cancellationToken: cancellationToken);
            await _announcementTypeBusinessRules.AnnouncementTypeShouldExistWhenSelected(announcementType);

            GetByIdAnnouncementTypeResponse response = _mapper.Map<GetByIdAnnouncementTypeResponse>(announcementType);
            return response;
        }
    }
}