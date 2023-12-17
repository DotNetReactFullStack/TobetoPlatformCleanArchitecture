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

namespace Application.Features.ForeignLanguages.Commands.Create;

public class CreateForeignLanguageCommand : IRequest<CreatedForeignLanguageResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, ForeignLanguagesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetForeignLanguages";

    public class CreateForeignLanguageCommandHandler : IRequestHandler<CreateForeignLanguageCommand, CreatedForeignLanguageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IForeignLanguageRepository _foreignLanguageRepository;
        private readonly ForeignLanguageBusinessRules _foreignLanguageBusinessRules;

        public CreateForeignLanguageCommandHandler(IMapper mapper, IForeignLanguageRepository foreignLanguageRepository,
                                         ForeignLanguageBusinessRules foreignLanguageBusinessRules)
        {
            _mapper = mapper;
            _foreignLanguageRepository = foreignLanguageRepository;
            _foreignLanguageBusinessRules = foreignLanguageBusinessRules;
        }

        public async Task<CreatedForeignLanguageResponse> Handle(CreateForeignLanguageCommand request, CancellationToken cancellationToken)
        {
            ForeignLanguage foreignLanguage = _mapper.Map<ForeignLanguage>(request);

            await _foreignLanguageRepository.AddAsync(foreignLanguage);

            CreatedForeignLanguageResponse response = _mapper.Map<CreatedForeignLanguageResponse>(foreignLanguage);
            return response;
        }
    }
}