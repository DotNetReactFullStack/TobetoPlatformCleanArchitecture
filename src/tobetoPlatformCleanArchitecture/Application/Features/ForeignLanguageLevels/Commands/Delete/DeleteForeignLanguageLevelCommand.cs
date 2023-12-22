using Application.Features.ForeignLanguageLevels.Constants;
using Application.Features.ForeignLanguageLevels.Constants;
using Application.Features.ForeignLanguageLevels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ForeignLanguageLevels.Constants.ForeignLanguageLevelsOperationClaims;

namespace Application.Features.ForeignLanguageLevels.Commands.Delete;

public class DeleteForeignLanguageLevelCommand : IRequest<DeletedForeignLanguageLevelResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ForeignLanguageLevelsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetForeignLanguageLevels";

    public class DeleteForeignLanguageLevelCommandHandler : IRequestHandler<DeleteForeignLanguageLevelCommand, DeletedForeignLanguageLevelResponse>
    {
        private readonly IMapper _mapper;
        private readonly IForeignLanguageLevelRepository _foreignLanguageLevelRepository;
        private readonly ForeignLanguageLevelBusinessRules _foreignLanguageLevelBusinessRules;

        public DeleteForeignLanguageLevelCommandHandler(IMapper mapper, IForeignLanguageLevelRepository foreignLanguageLevelRepository,
                                         ForeignLanguageLevelBusinessRules foreignLanguageLevelBusinessRules)
        {
            _mapper = mapper;
            _foreignLanguageLevelRepository = foreignLanguageLevelRepository;
            _foreignLanguageLevelBusinessRules = foreignLanguageLevelBusinessRules;
        }

        public async Task<DeletedForeignLanguageLevelResponse> Handle(DeleteForeignLanguageLevelCommand request, CancellationToken cancellationToken)
        {
            ForeignLanguageLevel? foreignLanguageLevel = await _foreignLanguageLevelRepository.GetAsync(predicate: fll => fll.Id == request.Id, cancellationToken: cancellationToken);
            await _foreignLanguageLevelBusinessRules.ForeignLanguageLevelShouldExistWhenSelected(foreignLanguageLevel);

            await _foreignLanguageLevelRepository.DeleteAsync(foreignLanguageLevel!);

            DeletedForeignLanguageLevelResponse response = _mapper.Map<DeletedForeignLanguageLevelResponse>(foreignLanguageLevel);
            return response;
        }
    }
}