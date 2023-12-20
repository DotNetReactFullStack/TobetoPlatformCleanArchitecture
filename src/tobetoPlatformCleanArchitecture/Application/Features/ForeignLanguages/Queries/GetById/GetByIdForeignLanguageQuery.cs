using Application.Features.ForeignLanguages.Constants;
using Application.Features.ForeignLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ForeignLanguages.Constants.ForeignLanguagesOperationClaims;

namespace Application.Features.ForeignLanguages.Queries.GetById;

public class GetByIdForeignLanguageQuery : IRequest<GetByIdForeignLanguageResponse>
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdForeignLanguageQueryHandler : IRequestHandler<GetByIdForeignLanguageQuery, GetByIdForeignLanguageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IForeignLanguageRepository _foreignLanguageRepository;
        private readonly ForeignLanguageBusinessRules _foreignLanguageBusinessRules;

        public GetByIdForeignLanguageQueryHandler(IMapper mapper, IForeignLanguageRepository foreignLanguageRepository, ForeignLanguageBusinessRules foreignLanguageBusinessRules)
        {
            _mapper = mapper;
            _foreignLanguageRepository = foreignLanguageRepository;
            _foreignLanguageBusinessRules = foreignLanguageBusinessRules;
        }

        public async Task<GetByIdForeignLanguageResponse> Handle(GetByIdForeignLanguageQuery request, CancellationToken cancellationToken)
        {
            ForeignLanguage? foreignLanguage = await _foreignLanguageRepository.GetAsync(predicate: fl => fl.Id == request.Id, cancellationToken: cancellationToken);
            await _foreignLanguageBusinessRules.ForeignLanguageShouldExistWhenSelected(foreignLanguage);

            GetByIdForeignLanguageResponse response = _mapper.Map<GetByIdForeignLanguageResponse>(foreignLanguage);
            return response;
        }
    }
}