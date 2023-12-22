using Application.Features.AnnouncementTypes.Constants;
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

namespace Application.Features.AnnouncementTypes.Commands.Delete;

public class DeleteAnnouncementTypeCommand : IRequest<DeletedAnnouncementTypeResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, AnnouncementTypesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetAnnouncementTypes";

    public class DeleteAnnouncementTypeCommandHandler : IRequestHandler<DeleteAnnouncementTypeCommand, DeletedAnnouncementTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAnnouncementTypeRepository _announcementTypeRepository;
        private readonly AnnouncementTypeBusinessRules _announcementTypeBusinessRules;

        public DeleteAnnouncementTypeCommandHandler(IMapper mapper, IAnnouncementTypeRepository announcementTypeRepository,
                                         AnnouncementTypeBusinessRules announcementTypeBusinessRules)
        {
            _mapper = mapper;
            _announcementTypeRepository = announcementTypeRepository;
            _announcementTypeBusinessRules = announcementTypeBusinessRules;
        }

        public async Task<DeletedAnnouncementTypeResponse> Handle(DeleteAnnouncementTypeCommand request, CancellationToken cancellationToken)
        {
            AnnouncementType? announcementType = await _announcementTypeRepository.GetAsync(predicate: at => at.Id == request.Id, cancellationToken: cancellationToken);
            await _announcementTypeBusinessRules.AnnouncementTypeShouldExistWhenSelected(announcementType);

            await _announcementTypeRepository.DeleteAsync(announcementType!);

            DeletedAnnouncementTypeResponse response = _mapper.Map<DeletedAnnouncementTypeResponse>(announcementType);
            return response;
        }
    }
}