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

namespace Application.Features.ForeignLanguageLevels.Commands.Create;

public class CreateForeignLanguageLevelCommand : IRequest<CreatedForeignLanguageLevelResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public int Priority { get; set; }
    public bool Visibility { get; set; }

    public string[] Roles => new[] { Admin, Write, ForeignLanguageLevelsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetForeignLanguageLevels";

    public class CreateForeignLanguageLevelCommandHandler : IRequestHandler<CreateForeignLanguageLevelCommand, CreatedForeignLanguageLevelResponse>
    {
        private readonly IMapper _mapper;
        private readonly IForeignLanguageLevelRepository _foreignLanguageLevelRepository;
        private readonly ForeignLanguageLevelBusinessRules _foreignLanguageLevelBusinessRules;

        public CreateForeignLanguageLevelCommandHandler(IMapper mapper, IForeignLanguageLevelRepository foreignLanguageLevelRepository,
                                         ForeignLanguageLevelBusinessRules foreignLanguageLevelBusinessRules)
        {
            _mapper = mapper;
            _foreignLanguageLevelRepository = foreignLanguageLevelRepository;
            _foreignLanguageLevelBusinessRules = foreignLanguageLevelBusinessRules;
        }

        public async Task<CreatedForeignLanguageLevelResponse> Handle(CreateForeignLanguageLevelCommand request, CancellationToken cancellationToken)
        {
            ForeignLanguageLevel foreignLanguageLevel = _mapper.Map<ForeignLanguageLevel>(request);

            await _foreignLanguageLevelRepository.AddAsync(foreignLanguageLevel);

            CreatedForeignLanguageLevelResponse response = _mapper.Map<CreatedForeignLanguageLevelResponse>(foreignLanguageLevel);
            return response;
        }
    }
}