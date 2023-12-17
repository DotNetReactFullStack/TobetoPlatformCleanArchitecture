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

namespace Application.Features.AnnouncementTypes.Commands.Create;

public class CreateAnnouncementTypeCommand : IRequest<CreatedAnnouncementTypeResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, AnnouncementTypesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAnnouncementTypes";

    public class CreateAnnouncementTypeCommandHandler : IRequestHandler<CreateAnnouncementTypeCommand, CreatedAnnouncementTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAnnouncementTypeRepository _announcementTypeRepository;
        private readonly AnnouncementTypeBusinessRules _announcementTypeBusinessRules;

        public CreateAnnouncementTypeCommandHandler(IMapper mapper, IAnnouncementTypeRepository announcementTypeRepository,
                                         AnnouncementTypeBusinessRules announcementTypeBusinessRules)
        {
            _mapper = mapper;
            _announcementTypeRepository = announcementTypeRepository;
            _announcementTypeBusinessRules = announcementTypeBusinessRules;
        }

        public async Task<CreatedAnnouncementTypeResponse> Handle(CreateAnnouncementTypeCommand request, CancellationToken cancellationToken)
        {
            AnnouncementType announcementType = _mapper.Map<AnnouncementType>(request);

            await _announcementTypeRepository.AddAsync(announcementType);

            CreatedAnnouncementTypeResponse response = _mapper.Map<CreatedAnnouncementTypeResponse>(announcementType);
            return response;
        }
    }
}