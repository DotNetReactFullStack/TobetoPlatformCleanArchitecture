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

namespace Application.Features.ForeignLanguageLevels.Commands.Update;

public class UpdateForeignLanguageLevelCommand : IRequest<UpdatedForeignLanguageLevelResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, ForeignLanguageLevelsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetForeignLanguageLevels";

    public class UpdateForeignLanguageLevelCommandHandler : IRequestHandler<UpdateForeignLanguageLevelCommand, UpdatedForeignLanguageLevelResponse>
    {
        private readonly IMapper _mapper;
        private readonly IForeignLanguageLevelRepository _foreignLanguageLevelRepository;
        private readonly ForeignLanguageLevelBusinessRules _foreignLanguageLevelBusinessRules;

        public UpdateForeignLanguageLevelCommandHandler(IMapper mapper, IForeignLanguageLevelRepository foreignLanguageLevelRepository,
                                         ForeignLanguageLevelBusinessRules foreignLanguageLevelBusinessRules)
        {
            _mapper = mapper;
            _foreignLanguageLevelRepository = foreignLanguageLevelRepository;
            _foreignLanguageLevelBusinessRules = foreignLanguageLevelBusinessRules;
        }

        public async Task<UpdatedForeignLanguageLevelResponse> Handle(UpdateForeignLanguageLevelCommand request, CancellationToken cancellationToken)
        {
            ForeignLanguageLevel? foreignLanguageLevel = await _foreignLanguageLevelRepository.GetAsync(predicate: fll => fll.Id == request.Id, cancellationToken: cancellationToken);
            await _foreignLanguageLevelBusinessRules.ForeignLanguageLevelShouldExistWhenSelected(foreignLanguageLevel);
            foreignLanguageLevel = _mapper.Map(request, foreignLanguageLevel);

            await _foreignLanguageLevelRepository.UpdateAsync(foreignLanguageLevel!);

            UpdatedForeignLanguageLevelResponse response = _mapper.Map<UpdatedForeignLanguageLevelResponse>(foreignLanguageLevel);
            return response;
        }
    }
}