using Application.Features.ForeignLanguages.Constants;
using Application.Features.ForeignLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ForeignLanguages.Constants.ForeignLanguagesOperationClaims;

namespace Application.Features.ForeignLanguages.Commands.Update;

public class UpdateForeignLanguageCommand : IRequest<UpdatedForeignLanguageResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, ForeignLanguagesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetForeignLanguages";

    public class UpdateForeignLanguageCommandHandler : IRequestHandler<UpdateForeignLanguageCommand, UpdatedForeignLanguageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IForeignLanguageRepository _foreignLanguageRepository;
        private readonly ForeignLanguageBusinessRules _foreignLanguageBusinessRules;

        public UpdateForeignLanguageCommandHandler(IMapper mapper, IForeignLanguageRepository foreignLanguageRepository,
                                         ForeignLanguageBusinessRules foreignLanguageBusinessRules)
        {
            _mapper = mapper;
            _foreignLanguageRepository = foreignLanguageRepository;
            _foreignLanguageBusinessRules = foreignLanguageBusinessRules;
        }

        public async Task<UpdatedForeignLanguageResponse> Handle(UpdateForeignLanguageCommand request, CancellationToken cancellationToken)
        {
            ForeignLanguage? foreignLanguage = await _foreignLanguageRepository.GetAsync(predicate: fl => fl.Id == request.Id, cancellationToken: cancellationToken);
            await _foreignLanguageBusinessRules.ForeignLanguageShouldExistWhenSelected(foreignLanguage);
            foreignLanguage = _mapper.Map(request, foreignLanguage);

            await _foreignLanguageRepository.UpdateAsync(foreignLanguage!);

            UpdatedForeignLanguageResponse response = _mapper.Map<UpdatedForeignLanguageResponse>(foreignLanguage);
            return response;
        }
    }
}