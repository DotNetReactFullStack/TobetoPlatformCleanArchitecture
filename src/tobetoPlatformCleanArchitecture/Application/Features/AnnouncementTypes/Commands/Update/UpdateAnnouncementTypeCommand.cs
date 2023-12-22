using Application.Features.AnnouncementTypes.Constants;
using Application.Features.AnnouncementTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.AnnouncementTypes.Constants.AnnouncementTypesOperationClaims;

namespace Application.Features.AnnouncementTypes.Commands.Update;

public class UpdateAnnouncementTypeCommand : IRequest<UpdatedAnnouncementTypeResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, AnnouncementTypesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAnnouncementTypes";

    public class UpdateAnnouncementTypeCommandHandler : IRequestHandler<UpdateAnnouncementTypeCommand, UpdatedAnnouncementTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAnnouncementTypeRepository _announcementTypeRepository;
        private readonly AnnouncementTypeBusinessRules _announcementTypeBusinessRules;

        public UpdateAnnouncementTypeCommandHandler(IMapper mapper, IAnnouncementTypeRepository announcementTypeRepository,
                                         AnnouncementTypeBusinessRules announcementTypeBusinessRules)
        {
            _mapper = mapper;
            _announcementTypeRepository = announcementTypeRepository;
            _announcementTypeBusinessRules = announcementTypeBusinessRules;
        }

        public async Task<UpdatedAnnouncementTypeResponse> Handle(UpdateAnnouncementTypeCommand request, CancellationToken cancellationToken)
        {
            AnnouncementType? announcementType = await _announcementTypeRepository.GetAsync(predicate: at => at.Id == request.Id, cancellationToken: cancellationToken);
            await _announcementTypeBusinessRules.AnnouncementTypeShouldExistWhenSelected(announcementType);
            announcementType = _mapper.Map(request, announcementType);

            await _announcementTypeRepository.UpdateAsync(announcementType!);

            UpdatedAnnouncementTypeResponse response = _mapper.Map<UpdatedAnnouncementTypeResponse>(announcementType);
            return response;
        }
    }
}